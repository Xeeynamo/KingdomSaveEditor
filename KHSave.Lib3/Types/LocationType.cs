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

namespace KHSave.Lib3.Types
{
	public enum LocationType : byte
	{
		[Info("The City / North District")] Location00,
		[Info("The City / Central District")] Location01,
		[Info("The City / South District")] Location02,
		[Info("Hiro's Garage")] Location03,
		[Info("The High Seas / Port Royal Waters")] Location04,
		[Info("The High Seas / Northern Waters")] Location05,
		[Info("The High Seas / Southern Waters")] Location06,
		[Info("The High Seas / Huddled Isles")] Location07,
		[Info("The High Seas / Undersea Cavern")] Location08,
		[Info("The High Seas / Sandbar Isle")] Location09,
		[Info("The High Seas / Forsaken Isle")] Location0a,
		[Info("The High Seas / Isla Verdemontaña")] Location0b,
		[Info("The High Seas / Isla de los Mástiles")] Location0c,
		[Info("Port Royal / Docks")] Location0d,
		[Info("Port Royal / Seaport")] Location0e,
		[Info("Port Royal / Fort")] Location0f,
		[Info("Port Royal / Settlement")] Location10,
		[Info("Port Royal / Dockside Path")] Location11,
		[Info("Port Royal")] Location12,
		[Info("Over the Edge")] Location13,
		[Info("The Labyrinth of Ice / Lower Tier")] Location14,
		[Info("The Labyrinth of Ice / Middle Tier")] Location15,
		[Info("The Labyrinth of Ice / Upper Tier")] Location16,
		[Info("The North Mountain / Mountain Ridge")] Location17,
		[Info("The North Mountain / Ice Palace")] Location18,
		[Info("The North Mountain / Treescape")] Location19,
		[Info("The North Mountain / Gorge")] Location1a,
		[Info("The North Mountain / Valley of Ice")] Location1b,
		[Info("The North Mountain / Frozen Wall")] Location1c,
		[Info("The North Mountain / Snowfield")] Location1d,
		[Info("The North Mountain / Fjord")] Location1e,
		[Info("The North Mountain / Foothills")] Location1f,
		[Info("Monsters. Inc. / Lobby & Offices")] Location20,
		[Info("Monsters. Inc. / Laugh Room")] Location21,
		[Info("The Factory / Basement")] Location22,
		[Info("The Factory / Ground Floor")] Location23,
		[Info("The Factory / Second Floor")] Location24,
		[Info("The Power Plant / Accessway")] Location25,
		[Info("The Power Plant / Tank Yard")] Location26,
		[Info("The Power Plant / Vault Passage")] Location27,
		[Info("The Door Vault / Upper Level")] Location28,
		[Info("The Door Vault / Lower Level")] Location29,
		[Info("The Door Vault / Service Area")] Location2a,
		[Info("Andy's House")] Location2b,
		[Info("Galaxy Toys / Main Floor: 1F")] Location2c,
		[Info("Galaxy Toys / Main Floor: 2F")] Location2d,
		[Info("Galaxy Toys / Main Floor: 3F")] Location2e,
		[Info("Galaxy Toys / Babies & Toddlers: Dolls")] Location2f,
		[Info("Galaxy Toys / Babies & Toddlers: Outdoors")] Location30,
		[Info("Galaxy Toys / Lower Vents")] Location31,
		[Info("Galaxy Toys / Upper Vents")] Location32,
		[Info("Galaxy Toys / Action Figures")] Location33,
		[Info("Galaxy Toys / Video Games")] Location34,
		[Info("Galaxy Toys / Kid Korral")] Location35,
		[Info("Galaxy Toys / Rest Area")] Location36,
		[Info("The Neighborhood / Tram Common")] Location37,
		[Info("The Neighborhood / Underground Conduit")] Location38,
		[Info("The Neighborhood / The Woods")] Location39,
		[Info("The Neighborhood / The Old Mansion")] Location3a,
		[Info("Realm of the Gods / Courtyard")] Location3b,
		[Info("Realm of the Gods / Corridors")] Location3c,
		[Info("Realm of the Gods / Secluded Forge")] Location3d,
		[Info("Realm of the Gods / Cloud Ridge")] Location3e,
		[Info("Realm of the Gods / Apex")] Location3f,
		[Info("Mount Olympus / Ravine")] Location40,
		[Info("Mount Olympus / Cliff Ascent")] Location41,
		[Info("Mount Olympus / Mountainside")] Location42,
		[Info("Mount Olympus / Summit")] Location43,
		[Info("Thebes / Agora")] Location44,
		[Info("Thebes / Gardens")] Location45,
		[Info("Thebes / Overlook")] Location46,
		[Info("Thebes / The Big Olive")] Location47,
		[Info("Thebes / Alleyway")] Location48,
		[Info("The Forest / Tower")] Location49,
		[Info("The Forest / Hills")] Location4a,
		[Info("The Forest / Marsh")] Location4b,
		[Info("The Forest / Campsite")] Location4c,
		[Info("The Forest / Wetlands")] Location4d,
		[Info("The Forest / Wildflower Clearing")] Location4e,
		[Info("The Forest / Shore")] Location4f,
		[Info("The Kingdom / Thoroughfare")] Location50,
		[Info("The Kingdom / Wharf")] Location51,
		[Info("The Badlands")] Location52,
		[Info("The Skein of Severance / Trail of Valediction")] Location53,
		[Info("The Skein of Severance / Twist of Isolation")] Location54,
		[Info("The Skein of Severance / Tower of Endings")] Location55,
		[Info("Rabbit's House")] Location56,
		[Info("The Stairway to the Sky")] Location57,
		[Info("The Realm of Darkness")] Location58,
		[Info("Worldmap")] Location59,
		[Info("The Final World")] Location5a,
		[Info("The Land of Departure")] Location5b,
		[Info("The Bridge")] Location5c,
		[Info("Davy Jones' Locker")] Location5d,
		[Info("The Realm of Darkness")] Location5e,
	}
}
