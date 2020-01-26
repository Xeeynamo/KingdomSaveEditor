using Xe.Tools;

namespace KHSave.SaveEditor.ViewModels
{
    public class HomeViewModel : BaseNotifyPropertyChanged
    {
        private const string DefaultFundLink = "https://github.com/sponsors/Xeeynamo";
        private string fundLink;

        public string FundLink
        {
            get => fundLink;
            set { fundLink = value; OnPropertyChanged(); }
        }

        public HomeViewModel()
        {
            FundLink = DefaultFundLink;
        }
    }
}
