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

using KHSave.Extensions;
using KHSave.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KHSave.Attributes
{
	public class InfoAttribute : Attribute
    {
        private static CacheService<string> cache = new CacheService<string>();

        public string Info { get; }

		public InfoAttribute()
		{ }

		public InfoAttribute(string info)
		{
			Info = info;
		}

        public static string GetInfo(object value) => cache.Get(value, x =>
            value.GetAttribute<InfoAttribute>()?.Info ?? x?.ToString() ?? "<null>");

        public static string[] GetItemTypes(object value)
		{
			var memberValue = value.ToString();
			var memberInfo = value.GetType().GetMember(memberValue).FirstOrDefault();

			if (memberInfo != null)
            {
                return memberInfo.CustomAttributes
                    .Select(x => GetTypeRecursive(x.AttributeType))
                    .SelectMany(x => x)
                    .Where(x => x != null)
                    .Select(x =>
                    {
                        var name = x.Name;
                        var indexAttributeStr = name.IndexOf("Attribute");
                        return indexAttributeStr > 0 ? name.Substring(0, indexAttributeStr) : null;
                    }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            }

			return new string[0];
		}

        private static IEnumerable<Type> GetTypeRecursive(Type type) =>
            new Type[] { type, }.Concat(type != null ? GetTypeRecursive(type.BaseType) : new Type[] { });
	}
}
