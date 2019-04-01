﻿/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

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

namespace KHSave.SaveEditor.Common
{
	public static class Global
	{
        //public static bool IsAdvancedMode
        //{
        //	get => Properties.Settings.Default.AdvancedMode;
        //	set
        //	{
        //		Properties.Settings.Default.AdvancedMode = value;
        //		Properties.Settings.Default.Save();
        //	}
        //}

        public static bool IsAdvancedMode { get; set; }


        public static bool CanDisplay(object item)
		{
			return IsAdvancedMode ||
				item.GetType() == typeof(string) ||
				!UnusedAttribute.IsUnused(item);
		}
	}
}