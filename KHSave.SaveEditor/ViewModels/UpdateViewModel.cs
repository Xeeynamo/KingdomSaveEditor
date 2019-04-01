using Xe.VersionCheck.Model;

namespace KHSave.SaveEditor.ViewModels
{
	public class UpdateViewModel
	{
		private readonly ReleaseVersion releaseVersion;

		public UpdateViewModel(ReleaseVersion releaseVersion)
		{
			this.releaseVersion = releaseVersion;

			ReleaseUrl = releaseVersion.PageUri;
			DownloadUrl = releaseVersion.DownloadUri;
		}

		public string ReleaseUrl { get; }

		public string DownloadUrl { get; set; }
	}
}
