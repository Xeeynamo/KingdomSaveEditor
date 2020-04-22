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

using System.Collections.Generic;

namespace KHSave.LibFf7Remake
{
    public class Presets
    {
        public class TeleportLocation
        {
            public int Chapter { get; }
            public string Name { get; }
            public float PositionX { get; }
            public float PositionY { get; }
            public float PositionZ { get; }

            public TeleportLocation(int chapter, string name, float x, float y, float z)
            {
                Chapter = chapter;
                Name = name;
                PositionX = x;
                PositionY = y;
                PositionZ = z;
            }
            public TeleportLocation(int chapter, string name, double x, double y, double z)
            {
                Chapter = chapter;
                Name = name;
                PositionX = (float)x;
                PositionY = (float)y;
                PositionZ = (float)z;
            }
        }

        public static List<TeleportLocation> TeleportLocations = new List<TeleportLocation>
        {
            new TeleportLocation(1, "Inside the train station", 5483.766, -8462.45, 6662.088),
            new TeleportLocation(1, "End of Chapter 1", 14145, -10470, 5290),
            new TeleportLocation(2, "Beginning of Chapter 2", -24580.36, -12204.58, -228.8734),
            new TeleportLocation(2, "Nibhelim flashback pt.1", -21708.71, -1268.751, -80),
            new TeleportLocation(2, "Nibhelim flashback pt.2", -18852.58, -3145.46, -39.16602),
            new TeleportLocation(2, "Before meeting Aerith", -14485.03, -898.4921, -69.99866),
            new TeleportLocation(2, "Before battling The Huntsman", 19275.55, 3117.768, -579.7065),
            new TeleportLocation(2, "In the train", 8.310989, -10064.3, -5000),
        };
    }
}
