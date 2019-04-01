using System.Diagnostics;
using System.Windows;
using Xe.Tools.Wpf.Commands;
using Xe.VersionCheck.Model;

namespace KHSave.SaveEditor.Views
{
	/// <summary>
	/// Interaction logic for UpdateWindow.xaml
	/// </summary>
	public partial class UpdateWindow : Window
	{
		private readonly ReleaseVersion lastVersion;

		public UpdateWindow(ReleaseVersion lastVersion)
		{
			InitializeComponent();

			DataContext = this;
			this.lastVersion = lastVersion;

			DownloadCommand = new RelayCommand(x =>
			{
				Process.Start(new ProcessStartInfo(lastVersion.DownloadUri));
			});

			CancelCommand = new RelayCommand(x =>
			{
				Close();
			});
		}

		public string PageUri => lastVersion.PageUri;

		public RelayCommand DownloadCommand { get; }

		public RelayCommand CancelCommand { get; }

		private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}
	}
}
