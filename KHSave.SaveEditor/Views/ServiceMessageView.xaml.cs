using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace KHSave.SaveEditor.Views
{
    /// <summary>
    /// Interaction logic for ServiceMessageView.xaml
    /// </summary>
    public partial class ServiceMessageView : UserControl
    {
        public ServiceMessageView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Text { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public double MyFontSize { get; set; }

        public Visibility UrlVisibility => string.IsNullOrEmpty(Url) ? Visibility.Collapsed : Visibility.Visible;
        public FontWeight MyFontWeight => IsBold ? FontWeights.Bold : FontWeights.Normal;
        public FontStyle MyFontStyle => IsItalic ? FontStyles.Italic : FontStyles.Italic;

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
