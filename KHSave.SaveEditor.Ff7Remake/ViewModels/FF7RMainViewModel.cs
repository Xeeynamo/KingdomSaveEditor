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

using KHSave.LibFf7Remake;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Contracts;
using System.IO;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class FF7RMainViewModel : BaseNotifyPropertyChanged, IRefreshUi, IOpenStream, IWriteToStream
    {
        public SaveFf7Remake Save { get; private set; }

        public CharactersViewModel Characters { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public MateriaViewModel Materia { get; set; }
        public EquipmentsViewModel Equipments { get; set; }
        public ChaptersViewModel Chapters { get; set; }
        public DeveloperViewModel Developer { get; set; }
        public Unknown3ViewModel Unk3 { get; set; }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public void RefreshUi()
        {
            Equipments = new EquipmentsViewModel(Save, Materia);
            Materia = new MateriaViewModel(Save);
            Characters = new CharactersViewModel(Save, Equipments, Materia);
            Inventory = new InventoryViewModel(Save);
            Chapters = new ChaptersViewModel(Save);
            Developer = new DeveloperViewModel(Save, this);
            Unk3 = new Unknown3ViewModel(Save);

            OnPropertyChanged(nameof(SimpleVisibility));
            OnPropertyChanged(nameof(AdvancedVisibility));
            OnPropertyChanged(nameof(Characters));
            OnPropertyChanged(nameof(Inventory));
            OnPropertyChanged(nameof(Materia));
            OnPropertyChanged(nameof(Equipments));
            OnPropertyChanged(nameof(Chapters));
            OnPropertyChanged(nameof(Developer));
            OnPropertyChanged(nameof(Unk3));
        }

        public void OpenStream(Stream stream)
        {
            Save = SaveFf7Remake.Read(stream);
            RefreshUi();
        }

        public void WriteToStream(Stream stream) =>
            Save.Write(stream);
    }
}
