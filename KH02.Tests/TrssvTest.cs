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

using System.IO;
using Xunit;

namespace KHSave.Tests
{
	public class TrssvTest
	{
		private readonly Trssv save;

		public TrssvTest()
		{
			using (var stream = File.OpenRead("Saves/kh02.sav"))
			{
				save = Trssv.Read(stream);
			}
		}

		[Fact]
		public void Test1()
		{
			Assert.Equal("/Game/Levels/dw/dw_08/dw_08", save.MapName);
		}
	}
}
