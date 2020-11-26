using System.Diagnostics;
using System.Windows.Controls;

namespace KHSave.SaveEditor.Ff7Remake.Views
{
    /// <summary>
    /// Interaction logic for InventoryEntryView.xaml
    /// </summary>
    public partial class InventoryEntryView : UserControl
    {
        public InventoryEntryView()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
