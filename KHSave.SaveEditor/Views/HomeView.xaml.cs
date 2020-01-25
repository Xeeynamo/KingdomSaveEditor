using KHSave.SaveEditor.Services;
using KHSave.SaveEditor.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KHSave.SaveEditor.Views
{
    /// <summary>
    /// Interaction logic for UnloadedView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            patronList.Children.Add(new Label()
            {
                Content = "Fetching the list of funders from the internet..."
            });

            Task.Run(async () =>
            {
                try
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
                        (DataContext as HomeViewModel).FundLink = patreonInfo.PatreonUrl;
                        patronList.Children.Clear();
                        foreach (var patronView in patronViews)
                        {
                            patronList.Children.Add(patronView);
                        }
                    });
                }
                catch
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        patronList.Children.Clear();
                        patronList.Children.Add(new Label()
                        {
                            Content = "Unable to retrieve the list of funders form internet."
                        });
                    });
                }
            });
        }
    }
}
