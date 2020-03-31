using KHSave.Archives;
using KHSave.SaveEditor.Common.ViewModels;
using System.IO;
using System.Windows;

namespace KHSave.SaveEditor.Common.Views
{
    /// <summary>
    /// Interaction logic for ArchiveManagerView.xaml
    /// </summary>
    public partial class ArchiveManagerView : Window
    {
        public ArchiveManagerView()
        {
            InitializeComponent();
        }

        public ArchiveManagerViewModel ViewModel
        {
            get => DataContext as ArchiveManagerViewModel;
            set => DataContext = value;
        }

        public void SetArchive(IArchive archive, string archvieFileName) =>
            ViewModel = new ArchiveManagerViewModel(this, archive, archvieFileName);

        public IArchiveEntry SelectedEntry => ViewModel?.SelectedEntry;

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
