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

using System.IO;
using Xe.Tools;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.Lib3;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
	public class Kh3ViewModel : BaseNotifyPropertyChanged, IRefreshUi, IOpenStream, IWriteToStream
    {
        public ISaveKh3 Save { get; private set; }
		
        public SystemViewModel KhSystem { get; set; }
		public InventoryViewModel Inventory { get; set; }
        public MaterialsViewModel Materials { get; set; }
		public PlayersViewModel Players { get; set; }
		public PartyViewModel Party { get; set; }
		public StoryViewModel Story { get; set; }
		public ShortcutsViewModel Shortcuts { get; set; }
		public RecordsViewModel Records { get; set; }
		public PhotosViewModel Photos { get; set; }

		public Kh3ViewModel()
		{
        }

		public void RefreshUi()
		{
			KhSystem = new SystemViewModel(Save);
			Inventory = new InventoryViewModel(Save.Inventory);
			Materials = new MaterialsViewModel(Save);
			Players = new PlayersViewModel(Save.Pc);
            Party = new PartyViewModel(Save);
			Story = new StoryViewModel(Save);
			Shortcuts = new ShortcutsViewModel(Save);
			Records = new RecordsViewModel(Save);
			Photos = new PhotosViewModel(Save.Photos);

			OnPropertyChanged(nameof(KhSystem));
			OnPropertyChanged(nameof(Inventory));
			OnPropertyChanged(nameof(Materials));
			OnPropertyChanged(nameof(Players));
			OnPropertyChanged(nameof(Party));
			OnPropertyChanged(nameof(Story));
			OnPropertyChanged(nameof(Shortcuts));
			OnPropertyChanged(nameof(Records));
			OnPropertyChanged(nameof(Photos));
        }

        public void OpenStream(Stream stream)
        {
            Save = SaveKh3.Read(stream);
            RefreshUi();
        }

        public void WriteToStream(Stream stream) => Save.Write(stream);
    }
}
