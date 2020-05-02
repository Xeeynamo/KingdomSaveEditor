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
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Properties;
using System.IO;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class FF7RMainViewModel : BaseNotifyPropertyChanged, IRefreshUi, IOpenStream, IWriteToStream
    {
        private const string DefaultTab = "Materia";

        public SaveFf7Remake Save { get; private set; }

        public CharactersViewModel Characters { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public MateriaViewModel Materia { get; set; }
        public EquipmentsViewModel CharacterEquipments { get; set; }
        public EquipmentsViewModel WeaponEquipments { get; set; }
        public ChaptersViewModel Chapters { get; set; }
        public GlobalViewModel Global { get; set; }
        public DeveloperViewModel Developer { get; set; }
        public Unknown1ViewModel Unk1 { get; set; }
        public Unknown2ViewModel Unk2 { get; set; }
        public Unknown3ViewModel Unk3 { get; set; }

        public Visibility SimpleVisibility => Common.Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Common.Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public string CurrentTabId
        {
            get => Settings.Default.LastFF7RTab ?? DefaultTab;
            set
            {
                Settings.Default.LastFF7RTab = value;
                Settings.Default.Save();
            }
        }

        public void RefreshUi()
        {
            CharacterEquipments = new EquipmentsViewModel(Save.CharacterMateria, Materia);
            WeaponEquipments = new EquipmentsViewModel(Save.WeaponMateria, Materia);
            Materia = new MateriaViewModel(Save);
            Characters = new CharactersViewModel(Save, WeaponEquipments, Materia);
            Inventory = new InventoryViewModel(Save);
            Chapters = new ChaptersViewModel(Save);
            Global = new GlobalViewModel(Save);
            Developer = new DeveloperViewModel(Save, this);
            Unk1 = new Unknown1ViewModel(Save);
            Unk2 = new Unknown2ViewModel(Save);
            Unk3 = new Unknown3ViewModel(Save);

            OnPropertyChanged(nameof(SimpleVisibility));
            OnPropertyChanged(nameof(AdvancedVisibility));
            OnPropertyChanged(nameof(Characters));
            OnPropertyChanged(nameof(Inventory));
            OnPropertyChanged(nameof(Materia));
            OnPropertyChanged(nameof(CharacterEquipments));
            OnPropertyChanged(nameof(WeaponEquipments));
            OnPropertyChanged(nameof(Chapters));
            OnPropertyChanged(nameof(Global));
            OnPropertyChanged(nameof(Developer));
            OnPropertyChanged(nameof(Unk1));
            OnPropertyChanged(nameof(Unk2));
            OnPropertyChanged(nameof(Unk3));
        }

        public void OpenStream(Stream stream)
        {
            if (SaveFf7Remake.IsUexp(stream))
                Save = SaveFf7Remake.ReadFromUexp(stream);
            else
                Save = SaveFf7Remake.Read(stream);

            RefreshUi();
        }

        public void WriteToStream(Stream stream) =>
            Save.Write(stream);
    }
}
