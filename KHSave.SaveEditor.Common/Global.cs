/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using KHSave.Attributes;
using System;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace KHSave.SaveEditor.Common
{
    internal class Settings : ApplicationSettingsBase
    {
        T Get<T>([CallerMemberName] string propertyName = null) => (T)this[propertyName];
        void Set<T>(T value, [CallerMemberName] string propertyName = null) => this[propertyName] = value;

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool AdvancedMode
        {
            get => Get<bool>();
            set => Set(value);
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool IsUpdateCheckingEnabled
        {
            get => Get<bool>();
            set => Set(value);
        }

        [UserScopedSetting]
        [DefaultSettingValue("0000-00-00")]
        public DateTime LastUpdateCheck
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        [UserScopedSetting]
        [DefaultSettingValue("Materia")]
        public string LastFF7RTab
        {
            get => Get<string>();
            set => Set(value);
        }

        [UserScopedSetting]
        [DefaultSettingValue("Characters")]
        public string LastPersona5Tab
        {
            get => Get<string>();
            set => Set(value);
        }

        [UserScopedSetting]
        [DefaultSettingValue("")]
        public string Cookie
        {
            get => Get<string>();
            set => Set(value);
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool AnonymousReporting
        {
            get => Get<bool>();
            set => Set(value);
        }
    }

    public static class Global
    {
        private static readonly Settings Settings = new Settings();

        public static bool IsAdvancedMode
        {
            get => Settings.AdvancedMode;
            set
            {
                Settings.AdvancedMode = value;
                Settings.Save();
            }
        }

        public static bool IsUpdateCheckingEnabled
        {
            get => Settings.IsUpdateCheckingEnabled;
            set
            {
                Settings.IsUpdateCheckingEnabled = value;
                Settings.Save();
            }
        }

        public static DateTime LastUpdateCheck
        {
            get => Settings.LastUpdateCheck;
            set
            {
                Settings.LastUpdateCheck = value;
                Settings.Save();
            }
        }

        public static string LastFF7RTab
        {
            get => Settings.LastFF7RTab;
            set
            {
                Settings.LastFF7RTab = value;
                Settings.Save();
            }
        }

        public static string LastPersona5Tab
        {
            get => Settings.LastPersona5Tab;
            set
            {
                Settings.LastPersona5Tab = value;
                Settings.Save();
            }
        }

        public static string Cookie
        {
            get => Settings.Cookie;
            set
            {
                Settings.Cookie = value;
                Settings.Save();
            }
        }

        public static bool AnonymousReporting
        {
            get => Settings.AnonymousReporting;
            set
            {
                Settings.AnonymousReporting = value;
                Settings.Save();
            }
        }


        public static bool CanDisplay(object item) => IsAdvancedMode || CanDisplayInBasicMode(item);

        public static bool CanDisplayInBasicMode(object item)
        {
            return item.GetType() == typeof(string) ||
                !UnusedAttribute.IsUnused(item);
        }
    }
}
