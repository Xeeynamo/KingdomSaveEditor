using KHSave.SaveEditor.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace KHSave.SaveEditor.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainWindowViewModel context;

        public MainWindow() :
            this(null)
        {

        }

		public MainWindow(string fileName)
		{
			InitializeComponent();
			DataContext = context = new MainWindowViewModel();

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                context.Open(fileName);
            }
        }

        private void Window_Loaded(object sender, EventArgs e)
		{
			Task.Run(async () =>
			{
				if (context.IsUpdateCheckingEnabled)
				{
					await context.CheckLastVersionAsync();
				}
			});
		}

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
