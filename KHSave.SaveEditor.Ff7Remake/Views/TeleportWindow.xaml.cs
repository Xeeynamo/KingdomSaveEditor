using KHSave.SaveEditor.Ff7Remake.Models;
using KHSave.SaveEditor.Ff7Remake.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace KHSave.SaveEditor.Ff7Remake.Views
{
    /// <summary>
    /// Interaction logic for TeleportWindow.xaml
    /// </summary>
    public partial class TeleportWindow : Window
    {
        public TeleportWindow(ChapterCharacterEntryModel chapterCharacter)
        {
            InitializeComponent();
            DataContext = new TeleportViewModel(chapterCharacter);
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }
    }
}
