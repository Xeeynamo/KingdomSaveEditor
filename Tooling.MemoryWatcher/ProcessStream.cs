using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Tooling.MemoryWatcher
{
	public class ProcessStream : Stream
	{
		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[DllImport("kernel32.dll")]
		private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int BytesRead);

		[DllImport("kernel32.dll")]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);
		
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle);


		private Process _process;
		private IntPtr _hProcess;
		private long position;

		public ProcessStream(Process process, uint baseAddress, uint length)
		{
			BaseAddress = baseAddress;
			Length = length;

			OpenProcess(process);
		}


		public uint BaseAddress { get; }
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
			var actualCount = (int)Math.Min(count, Math.Max(0, Length - Position));
			var pos = (IntPtr)(BaseAddress + Position);

			if (offset == 0)
			{
				ReadProcessMemory(_hProcess, pos, buffer, actualCount, out read);
			}
			else
			{
				byte[] data = new byte[actualCount];
				ReadProcessMemory(_hProcess, pos, buffer, actualCount, out read);
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
			var actualCount = (int)Math.Min(count, Math.Max(0, Length - Position));
			var pos = (IntPtr)(BaseAddress + Position);

			int written;
			if (offset == 0)
			{
				WriteProcessMemory(_hProcess, pos, buffer, actualCount, out written);
			}
			else
			{
				var data = new byte[count];
				Array.Copy(buffer, offset, data, 0, count);
				WriteProcessMemory(_hProcess, pos, data, actualCount, out written);
			}

			Position += written;
		}

		private void OpenProcess(Process process)
		{
			const int TOKEN_QUERY = 8;
			const int PROCESS_ALL_ACCESS = 0x000F0000 | 0x00100000 | 0xFFF;
			_hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);
			_process = process;

			var isSuccess = OpenProcessToken(_hProcess, TOKEN_QUERY, out var tokenHandle);
		}

		public static IEnumerable<Process> GetProcesses() =>
			Process.GetProcesses();

		public static Process TryGetProcess(Func<Process, bool> predicate, int timeout = 10000, int sleep = 100)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			do
			{
				var process = GetProcesses().FirstOrDefault(predicate);
				if (process != null)
					return process;

				Thread.Sleep(sleep);
			} while (stopwatch.ElapsedMilliseconds < timeout);

			return null;
		}

		public static Task<Process> TryGetProcessAsync(Func<Process, bool> predicate, int timeout = 10000, int sleep = 100) =>
			Task.Run(() => TryGetProcess(predicate, timeout, sleep));
	}
}
