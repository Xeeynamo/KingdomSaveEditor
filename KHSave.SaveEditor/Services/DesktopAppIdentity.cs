using System.Diagnostics;
using System.Reflection;

namespace KHSave.SaveEditor.Services
{
    public class DesktopAppIdentity : IAppIdentity
    {
        private static Assembly _assembly;
        private static FileVersionInfo _fvi;

        public DesktopAppIdentity()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _fvi = FileVersionInfo.GetVersionInfo(_assembly.Location);
        }

        public string Name => _fvi.ProductName;

        public string Version => _fvi.ProductVersion;
    }
}
