using Xe.Tools;

namespace KHSave.SaveEditor.ViewModels
{
    public class HomeViewModel : BaseNotifyPropertyChanged
    {
        private const string DefaultFundLink = "https://github.com/sponsors/Xeeynamo";
        private string _fundLink;
        private string _sponsorTitle;
        private string _sponsorDescription;
        private int _sponsorStartGoal;
        private int _sponsorEndGoal;
        private int _sponsorCount;

        public string FundLink
        {
            get => _fundLink;
            set { _fundLink = value; OnPropertyChanged(); }
        }

        public string SponsorHeaderInfo
        {
            get => _sponsorTitle;
            set
            {
                _sponsorTitle = value;
                OnPropertyChanged();
            }
        }

        public int SponsorCount
        {
            get => _sponsorCount;
            set
            {
                _sponsorCount = value;
                OnPropertyChanged();
            }
        }

        public int SponsorStartGoal
        {
            get => _sponsorStartGoal;
            set
            {
                _sponsorStartGoal = value;
                OnPropertyChanged();
            }
        }

        public int SponsorEndGoal
        {
            get => _sponsorEndGoal;
            set
            {
                _sponsorEndGoal = value;
                OnPropertyChanged();
            }
        }

        public string SponsorGoalDetails
        {
            get => _sponsorDescription;
            set
            {
                _sponsorDescription = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            FundLink = DefaultFundLink;
            _sponsorEndGoal = 1;
        }
    }
}
