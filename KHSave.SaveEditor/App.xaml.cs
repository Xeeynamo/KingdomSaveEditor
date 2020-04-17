using KHSave.SaveEditor.Interfaces;
using KHSave.SaveEditor.Services;
using KHSave.SaveEditor.ViewModels;
using KHSave.SaveEditor.Views;
using System.Diagnostics;
using System.Windows;
using Unity;

namespace KHSave.SaveEditor
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        private class ApplicationDebug : IApplicationDebug
        {
#if DEBUG
            public bool IsDebugging => Debugger.IsAttached;
#else
            public bool IsDebugging => false;
#endif

            public string TestFileName =>
                //"../../../../KHSave.Tests/Saves/BISLPM-66676COM-01";
                "../../../../KHSave.Tests/Saves/ff7remake007";
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer()
                .RegisterSingleton<IWindowManager, WindowManager>()
                .RegisterSingleton<IFileDialogManager, FileDialogManager>()
                .RegisterSingleton<IApplicationDebug, ApplicationDebug>()
                .RegisterSingleton<IAlertMessage, AlertMessage>()
                .RegisterSingleton<IUpdater, UpdaterService>()
                ;

            container.Resolve<MainWindow>().Show();
        }
    }
}
