using KHSave.SaveEditor.Interfaces;
using KHSave.SaveEditor.Services;
using KHSave.SaveEditor.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KHSave.SaveEditor.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainWindowViewModel context;
        private readonly IUpdater updater;

        public MainWindow(
            IWindowManager windowManager,
            IApplicationStartup applicationDebug,
            IUpdater updater,
            MainWindowViewModel vm)
		{
			InitializeComponent();
            windowManager.RootWindow = this;
            DataContext = context = vm;

            context.OnControlChanged = control =>
            {
                content.Children.Clear();
                content.Children.Add(control);
            };
            context.SaveKind = ContentType.Unload;

            if (!string.IsNullOrEmpty(applicationDebug.StartupFileName))
                context.Open(applicationDebug.StartupFileName);

            this.updater = updater;
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            Task.Run(() => updater.AutomaticallyCheckLastVersionAsync());
        }
    }
}
