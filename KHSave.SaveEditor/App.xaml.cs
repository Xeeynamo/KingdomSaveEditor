using System.Diagnostics;
using System.Windows;

namespace KHSave.SaveEditor
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        private Window window;

        protected override void OnStartup(StartupEventArgs e)
        {
            window = new MainWindow(GetFileName(e));
            window.Show();
        }

        private string GetFileName(StartupEventArgs e)
        {
            if (e.Args.Length > 0)
                return e.Args[0];

#if DEBUG
            if (Debugger.IsAttached)
            {
                return "../../../KHSave.Tests/Saves/kh3.bin";
            }
#endif
            return null;
        }
    }
}
