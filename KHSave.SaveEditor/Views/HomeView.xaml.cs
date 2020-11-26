using KHSave.SaveEditor.Services;
using KHSave.SaveEditor.ViewModels;
using System;
using System.Collections.Generic;
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

#if !DEBUG
            Task.Run(FetchAndPopulateSponsors());
#endif
        }

        private Func<Task> FetchAndPopulateSponsors()
        {
            return async () =>
            {
                try
                {
                    var patreonInfo = await new PatreonService(new DesktopAppIdentity()).GetPatreonInfo();
                    Application.Current.Dispatcher.Invoke(() => SetServerResponse(patreonInfo));
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
            };
        }

        private void SetServerResponse(Models.PatreonInfo patreonInfo)
        {
            var vm = DataContext as HomeViewModel;
            SetFundLink(vm, patreonInfo.PatreonUrl);
            SetSponsorList(vm, patreonInfo.Patrons);
            SetSponsorshipInfo(vm, patreonInfo.SponsorshipInfo);
            SetMessageList(vm, patreonInfo.Messages);
        }

        private void SetFundLink(HomeViewModel vm, string fundUrl) =>
            vm.FundLink = fundUrl;

        private void SetSponsorList(HomeViewModel vm, IEnumerable<Models.PatronModel> sponsors)
        {
            if (sponsors == null)
                return;

            var patronViews = sponsors
                .Select((patron, i) =>
                {
                    return new PatronView((i + 1) / 32.0, patron.Glow)
                    {
                        DataContext = new PatronViewModel(patron)
                    };
                })
                .Where(x => x != null);

            patronList.Children.Clear();
            foreach (var patronView in patronViews)
                patronList.Children.Add(patronView);
        }

        private void SetSponsorshipInfo(HomeViewModel vm, Models.SponsorshipInfo info)
        {
            if (info == null)
                return;

            vm.SponsorHeaderInfo = info.Title;
            vm.SponsorGoalDetails = info.Description;
            vm.SponsorStartGoal = info.StartGoal;
            vm.SponsorEndGoal = info.EndGoal;
            vm.SponsorCount = info.Count;
        }

        private void SetMessageList(HomeViewModel vm, IEnumerable<Models.ServiceMessage> messages)
        {
            if (messages == null)
                return;

            messageList.Children.Clear();
            foreach (var message in messages)
            {
                messageList.Children.Add(new Separator
                {
                    Margin = new Thickness(5)
                });

                messageList.Children.Add(new ServiceMessageView
                {
                    Margin = new Thickness(10, 0, 10, 0),
                    Text = message.Text,
                    Title = message.Title,
                    Url = string.IsNullOrEmpty(message.Url) ? "" : message.Url,
                    MyFontSize = message.FontSize <= 0 ? 12 : message.FontSize,
                    IsBold = message.IsBold,
                    IsItalic = message.IsItalic,
                });
            }
        }
    }
}
