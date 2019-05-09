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

using KHSave.Attributes;

namespace KHSave.Types
{
	public enum RecordShotlockType
	{
		[Info("Kingdom Key / King of Hearts Total Uses")] Usage00,
		[Info("Kingdom Key / Ragnarok Total Uses")] Usage01,
		[Info("Hero's Origin / Drain Shock Total Uses")] Usage02,
		[Info("Hero's Origin / Atomic Deluge Total Uses")] Usage03,
		[Info("Shooting Star / Meteor Shower Total Uses")] Usage04,
		[Info("Shooting Star / Diving Barrage Total Uses")] Usage05,
		[Info("Shooting Star / Cluster Cannonade Total Uses")] Usage06,
		[Info("Favorite Deputy / Ghost Horde Total Uses")] Usage07,
		[Info("Favorite Deputy / Drill Dive Total Uses")] Usage08,
		[Info("Ever After / Shimmering Drops Total Uses")] Usage09,
		[Info("Ever After / Spectral Rays Total Uses")] Usage0a,
		[Info("Happy Gear / Snakebite Total Uses")] Usage0b,
		[Info("Happy Gear / Warp Trick Total Uses")] Usage0c,
		[Info("Crystal Snow / Diamond Dust Total Uses")] Usage0d,
		[Info("Crystal Snow / Frozen Crescents Total Uses")] Usage0e,
		[Info("Wheel of Fate / Blade Storm Total Uses")] Usage0f,
		[Info("Wheel of Fate / Flag Rampage Total Uses")] Usage10,
		[Info("Nano Gear / Cubic Stream Total Uses")] Usage11,
		[Info("Nano Gear / Zone Connector Total Uses")] Usage12,
		[Info("Hunny Spout / Hunny Burst Total Uses")] Usage13,
		[Info("Hunny Spout / Hunny Drizzle Total Uses")] Usage14,
		[Info("Hunny Spout / Sweet Surprise Total Uses")] Usage15,
		[Info("Grand Chef / Steam Spiral Total Uses")] Usage16,
		[Info("Grand Chef / Fruit Crusher Total Uses")] Usage17,
		[Info("Classic Tone / Phantom Rush Total Uses")] Usage18,
		[Info("Classic Tone / Noise Flux Total Uses")] Usage19,
		[Info("Starlight / Knights of the Round Total Uses")] Usage1a,
		[Info("Starlight / Union Ragnarok Total Uses")] Usage1b,
		[Info("Ultima Weapon / Infinity Circle Total Uses")] Usage1c,
		[Unused] [Info("")] Usage1d,
		[Unused] [Info("")] Usage1e,
		[Unused] [Info("")] Usage1f,
	}
}
