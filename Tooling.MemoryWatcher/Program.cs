using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tooling.MemoryWatcher
{
    public static class Program
    {
        async static Task Main(string[] args)
        {
            var configFileName = Path.GetFullPath(args.FirstOrDefault() ?? "config.yml");
            var configuration = Configuration.ReadFromYaml(configFileName);

            Console.WriteLine("List of supported games:");
            for (var i = 0; i < configuration.Games.Count; i++)
            {
                var game = configuration.Games[i];
                Console.WriteLine($" {i:D2}. [{game.Process}] {game.Name}");
            }

            int selectedGame;
            do
            {
                Console.Write("What game do you want to watch? (eg. 3): ");
                if (!int.TryParse(Console.ReadLine(), out selectedGame))
                {
                    Console.WriteLine("ERROR: You did not typed a valid number?");
                    selectedGame = -1;
                }

                if (selectedGame >= configuration.Games.Count)
                {
                    Console.WriteLine("The game you selected does not exist.");
                    selectedGame = -1;
                }
            } while (selectedGame < 0);

            try
            {
                await Run(configFileName, configuration.Games[selectedGame]);
            }
            catch (ExecutionException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        async static Task Run(string configFileName, GameConfiguration game)
        {
            var processName = game.Process;
            Console.WriteLine($"Now searching for the process {processName}...");

            var process = await ProcessStream
                .TryGetProcessAsync(x => x.ProcessName.Contains(processName));
            if (process == null)
                throw new ExecutionException($"Failed to attach to {game.Process} in the time limit.");

            Console.WriteLine($"We suppose that {processName} has {game.Name} running.\n");
            Console.WriteLine(" [c] clear console");
            Console.WriteLine(" [d] dump memory to file");
            Console.WriteLine(" [p] pause/resume watch");
            Console.WriteLine(" [x] exit");
            Console.WriteLine("Now watching to memory differences...");

            bool isWatchRunning = true;
            bool isSupposedToExit = false;

            using var stream = new ProcessStream(process, game.Offset, game.Length);
            var taskInput = Task.Run(async () =>
            {
                while (!isSupposedToExit)
                {
                    switch (Console.ReadKey().KeyChar)
                    {
                        case 'c':
                            Console.Clear();
                            break;
                        case 'd':
                            lock (stream)
                                Dump(stream);
                            break;
                        case 'p':
                            isWatchRunning = !isWatchRunning;
                            if (isWatchRunning)
                                Console.WriteLine("Memory watcher is now scheduled to resume its watch!");
                            else
                                Console.WriteLine("Memory watcher is now scheduled to take a rest.");
                            break;
                        case 'x':
                            isSupposedToExit = true;
                            Console.WriteLine("Memory watcher is now scheduled to exit.");
                            break;
                    }

                    await Task.Delay(10);
                }
            });

            var taskWatch = Task.Run(async () =>
            {
                var length = game.Length;
                var buffer = new byte[length];
                var current = new byte[length];
                var sb = new StringBuilder(0x1000);

                stream.Position = 0;
                stream.Read(buffer, 0, (int)length);

                while (!isSupposedToExit)
                {
                    await Task.Delay(1);

                    lock (stream)
                    {
                        stream.Position = 0;
                        stream.Read(current);
                    }

                    if (isWatchRunning)
                    {
                        for (var i = 0U; i < length; i++)
                        {
                            if (buffer[i] != current[i])
                                sb.Append(LogDifference(i, buffer[i], current[i], game.Labels));
                        }
                    }

                    if (sb.Length > 0)
                    {
                        Console.Write(sb);
                        sb.Clear();
                    }

                    var tmp = buffer; // flip buffer for performance reasons
                    buffer = current;
                    current = tmp;

                }
            });

            using var fsWatcher = new FileSystemWatcher()
            {
                Path = Path.GetDirectoryName(configFileName),
                Filter = Path.GetFileName(configFileName),
                NotifyFilter = NotifyFilters.LastWrite,
                EnableRaisingEvents = true,
            };
            fsWatcher.Changed += (object sender, FileSystemEventArgs e) =>
            {
                //Console.WriteLine($"The configuration file {e.Name} has been changed and it will be reloaded.");
                Thread.Sleep(50);

                try
                {
                    var configuration = Configuration.ReadFromYaml(configFileName);
                    var gameNew = configuration.Games
                        .FirstOrDefault(x => x.Name == game.Name);

                    if (gameNew == null)
                        Console.WriteLine($"The configuration for the running game can not be found, so it will not be reloaded.");
                    else
                        game = gameNew;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading the configuration: {ex.Message}.");
                }
            };

            await Task.WhenAll(taskInput, taskWatch);
        }

        private static void Dump(ProcessStream stream)
        {
            var fileName = $"dump_{DateTime.Now.Ticks}.bin";

            using var outStream = File.Create(fileName);
            stream.Position = 0;
            stream.CopyTo(outStream);

            Console.WriteLine($"Dumped to {fileName}");
        }

        private static string LogDifference(uint offset, byte previous, byte current, List<GameLabelConfiguration> labels)
        {
            var label = GetLabel(labels, offset);
            if (!(label?.Hidden == true))
                return $"0x{offset:X06} {previous:X02} > {current:X02}  {label?.Comment}\n";

            return string.Empty;
        }

        private static GameLabelConfiguration GetLabel(List<GameLabelConfiguration> labels, uint offset)
        {
            if (labels == null)
                return null;

            foreach (var label in labels)
            {
                if (offset >= label.Offset && offset < label.Offset + label.Length)
                    return label;
            }

            return null;
        }

        static IEnumerable<int> IgnoreOffset(int offset)
        {
            yield return offset;
        }

        static IEnumerable<int> IgnoreOffset(int startOffset, int count) =>
            Enumerable.Range(startOffset, count);
    }

    public class ExecutionException : Exception
    {
        public ExecutionException(string message) :
            base(message)
        { }
    }
}
