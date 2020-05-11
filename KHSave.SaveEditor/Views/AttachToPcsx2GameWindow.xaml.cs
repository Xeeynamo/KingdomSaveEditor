using KHSave.SaveEditor.Services;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KHSave.SaveEditor.Views
{
    /// <summary>
    /// Interaction logic for AttachToPcsx2GameWindow.xaml
    /// </summary>
    public partial class AttachToPcsx2GameWindow : Window
    {
        private Stream _foundStream;

        public AttachToPcsx2GameWindow()
        {
            InitializeComponent();
        }

        public Stream WaitForGame(Process process)
        {
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var task = Task.Run(async () =>
                {
                    _foundStream = await Pcsx2MemoryService.CreateStreamFromPcsx2Process(process, cancellationTokenSource.Token);

                    // If the search ends, ask to close the current window dialog
                    Application.Current.Dispatcher.Invoke(() => Close());

                }, cancellationTokenSource.Token);

                ShowDialog();

                // If the search is still running, ask to it to terminate ASAP.
                cancellationTokenSource.Cancel();
            }

            return _foundStream;
        }
    }
}
