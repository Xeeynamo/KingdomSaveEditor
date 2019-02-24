using KH02.SaveEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KH02.SaveEditor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainWindowViewModel context;

		public MainWindow()
		{
			InitializeComponent();
			DataContext = context = new MainWindowViewModel();

#if DEBUG
			if (Debugger.IsAttached)
			{
				context.Open(@"..\..\..\KH02.Tests\Saves\kh3.bin");
			}
#endif
		}
	}
}
