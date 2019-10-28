using KHSave.SaveEditor.Services;
using KHSave.SaveEditor.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
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

        public MainWindow() :
            this(null)
        {

        }

		public MainWindow(string fileName)
		{
			InitializeComponent();
			DataContext = context = new MainWindowViewModel();

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                context.Open(fileName);
            }
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
                var patreonInfo = await PatreonService.GetPatreonInfo();
                var patronViews = patreonInfo.Patrons
                    .Select((patron, i) =>
                    {
                        Func<string, PatronViewModel> factory;
                        bool glow = patron.Glow;
                        switch (patron.TierId)
                        {
                            case 1:
                                factory = PatronViewModel.Bronze;
                                break;
                            case 2:
                                factory = PatronViewModel.Silver;
                                break;
                            case 3:
                                factory = PatronViewModel.Gold;
                                break;
                            case 4:
                                factory = PatronViewModel.Platinum;
                                break;
                            default:
                                return null;
                        }

                        return new PatronView((i + 1) / 32.0, glow)
                        {
                            DataContext = factory(patron.Name)
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
