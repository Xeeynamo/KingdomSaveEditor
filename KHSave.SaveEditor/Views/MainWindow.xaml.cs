using KHSave.SaveEditor.Interfaces;
using KHSave.SaveEditor.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace KHSave.SaveEditor.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainWindowViewModel context;

		public MainWindow(
            IWindowManager windowManager,
            IApplicationDebug applicationDebug,
            MainWindowViewModel vm)
		{
			InitializeComponent();
            windowManager.RootWindow = this;
            DataContext = context = vm;

            if (applicationDebug.IsDebugging)
                context.TestOpen(applicationDebug.TestFileName);
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                if (context.IsUpdateCheckingEnabled)
                {
                    await context.CheckLastVersionAsync();
                }
            });
        }
    }
}
