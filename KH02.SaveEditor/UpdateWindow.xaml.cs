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
using System.Windows.Shapes;
using Xe.Tools.Wpf.Commands;
using Xe.VersionCheck.Model;

namespace KH02.SaveEditor
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
