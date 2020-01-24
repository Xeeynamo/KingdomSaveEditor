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

namespace KHSave.Lib3.Types
{
	public enum StoryFlagType
	{
		[Info("Scala ad Caelum")] ScalaAdCaelum,
		[Info("San Fransokyo")] SanFransokyo,
		[Info("Caribbean")] Caribbean,
		[Info("")] Story03,
		[Info("")] Story04,
		[Info("")] Story05,
		[Info("")] Story06,
		[Info("Destiny Island")] DestinyIsland,
		[Info("Land of Departure")] LandOfDeparture,
		[Info("Dark World")] DarkWorld,
		[Info("")] Story0A,
		[Info("The Final World")] TheFinalWorld,
		[Info("")] Story0C,
		[Info("")] Story0D,
		[Info("")] Story0E,
		[Info("")] Story0F,
		[Info("")] Story10,
		[Info("")] Story11,
		[Info("")] Story12,
		[Info("")] Story13,
		[Info("Arendelle")] Arendelle,
		[Info("Arendelle Avalanche")] ArendelleAvalanche,
		[Info("Gummi")] Gummi,
		[Info("")] Story17,
		[Info("")] Story18,
		[Info("")] Story19,
		[Info("")] Story1A,
		[Info("")] Story1B,
		[Info("")] Story1C,
		[Info("Olympus")] Hercules,
		[Info("")] Story1E,
		[Info("Keyblade Graveyard")] KeybladeGraveyard,
		[Info("KG | Dark Riku, Xigbar")] KG_Riku_Xigbar,
		[Info("KG | Luxord, Marluxia, Larxene")] KG_Luxord_Marluxia_Larxene,
		[Info("KG | Vanitas, Terra-Xehanort")] KG_Vanitas_Terra,
		[Info("KG | Xion, Saix")] KG_Xion_Saix,
		[Info("Monstropolis")] Monstropolis,
		[Info("")] Story25,
		[Info("100 Acre Wood")] Pooh,
		[Info("Kingdom of Corona")] KingdomOfCorona,
		[Info("")] Story28,
		[Info("")] Story29,
		[Info("")] Story2A,
		[Info("")] Story2B,
		[Info("Radiant Garden")] RadiantGarden,
		[Info("Secret Forest")] SecretForest,
		[Info("Toy Box")] ToyBox,
		[Info("")] Story2F,
		[Info("Twilight Town")] TwilightTown,
		[Info("")] Story31,
		[Info("")] Story32,
		[Info("WM - Olympus")] Story33,
		[Info("WM - Twilight Town")] Story34,
		[Info("WM - Kingdom of Corona")] Story35,
		[Info("WM - Toy Story")] Story36,
		[Info("WM - Monstropolis")] Story37,
		[Info("WM - Arendelle")] Story38,
		[Info("WM - Caribbean")] Story39,
		[Info("WM - San Fransokyo")] Story3A,
		[Info("WM - Keyblade Graveyard")] Story3B,
		[Info("WM - Final World")] Story3C,
		[Info("World Map")] WorldMap,
		[Info("The Mysterious Tower")] MysteriousTower,
		[Info("")] Story3F
	}
}
