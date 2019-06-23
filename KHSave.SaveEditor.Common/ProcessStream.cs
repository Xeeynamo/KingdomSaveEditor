using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace KHSave.SaveEditor.Common
{
    public class ProcessStream : Stream
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int BytesRead);

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);


        [DllImport("kernel32.dll")]
        static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        Process process;
        IntPtr hProcess;
        private long position;

        public ProcessStream(Process process, long offset, long length)
        {
            Length = length;
            Offset = offset;
            OpenProcess(process);
        }

        public long Offset { get; }


        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => true;

        public override long Length { get; }

        public override long Position
        {
            get => position;
            set => position = value;
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int read;
            var pos = (IntPtr)(Offset + Position);

            if (offset == 0)
            {
                ReadProcessMemory(hProcess, pos, buffer, count, out read);
            }
            else
            {
                byte[] data = new byte[count];
                ReadProcessMemory(hProcess, pos, buffer, count, out read);
                Array.Copy(data, 0, buffer, offset, read);
            }

            Position += read;

            return read;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    return Position = offset;
                case SeekOrigin.Current:
                    return Position += offset;
                case SeekOrigin.End:
                    return Position = Length + offset;
                default:
                    return Position;
            }
        }

        public override void SetLength(long value)
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var pos = (IntPtr)(Offset + Position);

            int written;
            if (offset == 0)
            {
                WriteProcessMemory(hProcess, pos, buffer, count, out written);
            }
            else
            {
                var data = new byte[count];
                Array.Copy(buffer, offset, data, 0, count);
                WriteProcessMemory(hProcess, pos, data, count, out written);
            }

            Position += written;
        }

        private void OpenProcess(Process process)
        {
            var permissions = 0x001FFFFF;
            hProcess = OpenProcess(permissions, true, process.Id);
            this.process = process;

            var pos = (IntPtr)(0x20000000 + Position);
            VirtualProtectEx(hProcess, pos, (UIntPtr)Length, 0xFF, out var old);
        }

        public static ProcessStream SearchProcess(string processName, long offset, long length)
        {
            while (true)
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Contains(processName))
                    {
                        return new ProcessStream(process, offset, length);
                    }
                }

                Thread.Sleep(100);
            }
        }

        public static async Task<ProcessStream> SearchProcessAsync(string processName, long offset, long length)
        {
            return await Task.Run(() =>
            {
                return SearchProcess(processName, offset, length);
            });
        }
    }
}
