/*
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

using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Extensions
{
	public static class BitExtensions
	{
		public static bool GetFlag(this int value, int bit)
		{
			return (value & (1 << bit)) != 0;
		}

		public static int SetFlag(this int value, int bit, bool set)
		{
			if (set)
			{
				value |= 1 << bit;
			}
			else
			{
				value &= ~(1 << bit);
			}

			return value;
		}
	}
}
