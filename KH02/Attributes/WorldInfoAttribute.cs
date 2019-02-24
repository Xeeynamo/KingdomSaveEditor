/*
    Kingdom Hearts 0.2 and 3 Save Editor
    Copyright (C) 2019  Luciano Ciccariello

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

using System;
using System.Linq;
using KHSave.Types;

namespace KHSave.Attributes
{
	public class WorldAttribute : InfoAttribute
	{
		public string Id { get; set; }

		public WorldAttribute(string id, string name) :
			base(name)
		{
			Id = id;
		}

		public static string GetWorldId(object value)
		{
			var memberValue = value.ToString();
			var memberInfo = value.GetType().GetMember(memberValue).FirstOrDefault();

			if (memberInfo != null)
			{
				if (memberInfo.GetCustomAttributes(typeof(WorldAttribute), false)
					    .FirstOrDefault() is WorldAttribute attribute && !string.IsNullOrEmpty(attribute.Info))
				{
					return attribute.Id;
				}
			}

			return null;
		}
	}
}
