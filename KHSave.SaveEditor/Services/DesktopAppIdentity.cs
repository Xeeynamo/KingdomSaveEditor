using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

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

        private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();
        private static readonly string _assemblyLocation = Path
            .Combine(AppContext.BaseDirectory, _assembly.ManifestModule.ToString())
                .Replace(".dll", ".exe");
        private static readonly FileVersionInfo _fvi = FileVersionInfo.GetVersionInfo(_assemblyLocation);

        public DesktopAppIdentity()
        {
            var assembly;
            MessageBox.Show($"BaseDir: {AppContext.BaseDirectory}");
            MessageBox.Show($"ManifestModuleName: {assembly.ManifestModule}");
            var assemblyLocation = Path.Combine(AppContext.BaseDirectory, assembly.ManifestModule.ToString())
                .Replace(".dll", ".exe");
            MessageBox.Show($"Location: {assemblyLocation}");
            _fvi = FileVersionInfo.GetVersionInfo(assemblyLocation);
            MessageBox.Show($"FileVersionInfo: {_fvi}");

            // https://docs.microsoft.com/en-us/windows/msix/desktop/desktop-to-uwp-behind-the-scenes#installation
            IsMicrosoftStore = WindowsStorePathList.Any(x => AppContext.BaseDirectory.Contains(x));
        }

        public string Name => _fvi.ProductName;

        public string Version => _fvi.ProductVersion;

        public bool IsMicrosoftStore { get; }
    }
}
