using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace KHSave.SaveEditor.Services
{
    public class DesktopAppIdentity : IAppIdentity
    {
        private static readonly string[] WindowsStorePathList = new[]
        {
            "\\WindowsApps\\",
            "/WindowsApps/",
            "58821Xeeynamo.KingdomSaveEditor_",
        };

        private static Assembly _assembly;
        private static FileVersionInfo _fvi;

        public DesktopAppIdentity()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _fvi = FileVersionInfo.GetVersionInfo(_assembly.Location);

            // https://docs.microsoft.com/en-us/windows/msix/desktop/desktop-to-uwp-behind-the-scenes#installation
            IsMicrosoftStore = WindowsStorePathList.Any(x => _assembly.Location.Contains(x));
        }

        public string Name => _fvi.ProductName;

        public string Version => _fvi.ProductVersion;

        public bool IsMicrosoftStore { get; }
    }
}
