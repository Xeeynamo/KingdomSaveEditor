using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KHSave.SaveEditor.Views
{
    /// <summary>
    /// Interaction logic for AttachToProcessWindow.xaml
    /// </summary>
    public partial class AttachToProcessWindow : Window
    {
        private Process _foundProcess;

        public AttachToProcessWindow(string processName)
        {
            InitializeComponent();
            DataContext = this;

            _foundProcess = null;
            ProcessName = processName;
        }

        public string ProcessName { get; }

        public Process WaitForProcess()
        {
            // There might be a chance that the process is already there, so do not bother
            // to create the window for that.
            var process = GetFirstProcessOrDefault(ProcessName);
            if (process != null)
            {
                Close();
                return process;
            }

            // If not found, create a waiting dialog to give some feedback to the user.
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var task = Task.Run(async () =>
                {
                    await ProcessSearchAsync(cancellationTokenSource.Token);

                    // If the search ends, ask to close the current window dialog
                    Application.Current.Dispatcher.Invoke(() => Close());

                }, cancellationTokenSource.Token);

                ShowDialog();

                // If the search is still running, ask to it to terminate ASAP.
                cancellationTokenSource.Cancel();
            }

            return _foundProcess;
        }

        private async Task ProcessSearchAsync(CancellationToken token)
        {
            const int Delay = 100;
            while (!token.IsCancellationRequested)
            {
                var processes = Process.GetProcessesByName(ProcessName);
                if (processes.Length > 0)
                {
                    _foundProcess = processes[0];
                    return;
                }

                await Task.Delay(Delay);
            }
        }

        private static Process GetFirstProcessOrDefault(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            return processes.Length > 0 ? processes[0] : null;
        }
    }
}
