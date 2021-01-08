using System;
using System.Threading.Tasks;
using System.Windows;
using KHSave.SaveEditor.Common.Properties;
using KHSave.SaveEditor.Interfaces;
using KHSave.SaveEditor.VersionCheck;
using KHSave.SaveEditor.Views;
using Xe.VersionCheck;

namespace KHSave.SaveEditor.Services
{
    public class UpdaterService : IUpdater
    {
        private readonly IWindowManager windowManager;
        private readonly IAppIdentity _appIdentity;

        private bool IsItTimeForCheckingNewVersion
        {
            get
            {
                try
                {
                    return Settings.Default.LastUpdateCheck.AddDays(1) < DateTime.UtcNow;
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool IsAutomaticUpdatesEnabled
        {
            get => Settings.Default.IsUpdateCheckingEnabled;
            set
            {
                Settings.Default.IsUpdateCheckingEnabled = value;
                Settings.Default.Save();
            }
        }

        public UpdaterService(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
            _appIdentity = new DesktopAppIdentity();
        }

        public Task<bool> AutomaticallyCheckLastVersionAsync()
        {
            if (IsAutomaticUpdatesEnabled && IsItTimeForCheckingNewVersion)
                return ForceCheckLastVersionAsync();

            return Task.FromResult(true);
        }

        public async Task<bool> ForceCheckLastVersionAsync()
        {
            if (_appIdentity.IsMicrosoftStore)
                return false;

            UpdateLastTimeForCheckingNewVersion();
            var checkCurrentVersion = new DesktopCheckCurrentVersion();
            var checkLastVersion = new GithubCheckLatestVersion("xeeynamo", "kh3saveeditor");
            var releaseUpdater = new VersionChecker(checkCurrentVersion, checkLastVersion);

            var lastVersion = await releaseUpdater.GetLatestVersionAsync();
            if (lastVersion != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                    windowManager.Push(new UpdateWindow(lastVersion)));

                return true;
            }

            return false;
        }

        private void UpdateLastTimeForCheckingNewVersion()
        {
            Settings.Default.LastUpdateCheck = DateTime.UtcNow;
            Settings.Default.Save();
        }
    }
}
