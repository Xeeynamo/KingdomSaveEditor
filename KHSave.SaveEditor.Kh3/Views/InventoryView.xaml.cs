using KHSave.SaveEditor.Kh3.Models;
using KHSave.SaveEditor.Kh3.ViewModels;
using System.Windows.Controls;

namespace KHSave.SaveEditor.Kh3.Views
{
	/// <summary>
	/// Interaction logic for InventoryView.xaml
	/// </summary>
	public partial class InventoryView : UserControl
	{
		public InventoryView()
		{
			InitializeComponent();
		}

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is InventoryViewModel vm)
                vm.ChangeSelectedItems();
        }
    }
}
