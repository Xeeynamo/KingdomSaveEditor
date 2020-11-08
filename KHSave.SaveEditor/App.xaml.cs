using KHSave.SaveEditor.Ff7Remake.Data;
using KHSave.SaveEditor.Interfaces;
using KHSave.SaveEditor.Services;
using KHSave.SaveEditor.Views;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Unity;

namespace KHSave.SaveEditor
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        private class ApplicationStartup : IApplicationStartup
        {
            public ApplicationStartup(string[] args)
            {
                StartupFileName = args.FirstOrDefault();
#if DEBUG
                StartupFileName = StartupFileName ?? @"D:\Repository\KH3SaveEditor\KHSave.Tests\Saves\kh2fm.bin";
#endif
            }

#if DEBUG
            public bool IsDebugging => Debugger.IsAttached;
#else
            public bool IsDebugging => false;
#endif

            public string StartupFileName { get; }
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += (sender, args) =>
            {
                ReporterService.Instance.SendCrashReport(args.Exception);
                MessageBox.Show(
                    $"An unhandled error has occurred:\n{args.Exception.Message}\n\n{args.Exception.StackTrace}",
                    "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                args.Handled = true;
            };

            ItemsPreset.LazyInitialize();
            BgmPreset.LazyInitialize();

            IUnityContainer container = new UnityContainer()
                .RegisterSingleton<IWindowManager, WindowManager>()
                .RegisterSingleton<IFileDialogManager, FileDialogManager>()
                .RegisterInstance<IApplicationStartup>(new ApplicationStartup(e.Args))
                .RegisterSingleton<IAlertMessage, AlertMessage>()
                .RegisterSingleton<IUpdater, UpdaterService>()
                ;

            container.Resolve<MainWindow>().Show();
        }
    }
}
