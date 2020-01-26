using KHSave.SaveEditor.Services;
using Xe.VersionCheck;

namespace KHSave.SaveEditor.VersionCheck
{
	public class DesktopCheckCurrentVersion : ICheckCurrentVersion
	{
        private IAppIdentity _appIdentity;

        public DesktopCheckCurrentVersion()
        {
            _appIdentity = new DesktopAppIdentity();
        }

        public string GetCurrentVersion() => _appIdentity.Version;
	}
}
