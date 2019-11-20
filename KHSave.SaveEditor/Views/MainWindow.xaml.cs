using KHSave.SaveEditor.Interfaces;
using KHSave.SaveEditor.Services;
using KHSave.SaveEditor.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

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

            Task.Run(async () =>
            {
                var patreonInfo = await new PatreonService(new DesktopAppIdentity()).GetPatreonInfo();
                var patronViews = patreonInfo.Patrons
                    .Select((patron, i) =>
                    {
                        return new PatronView((i + 1) / 32.0, patron.Glow)
                        {
                            DataContext = new PatronViewModel(patron)
                        };
                    })
                    .Where(x => x != null);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    patronList.Children.Clear();
                    foreach (var patronView in patronViews)
                    {
                        patronList.Children.Add(patronView);
                    }
                });
            });
		}

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
