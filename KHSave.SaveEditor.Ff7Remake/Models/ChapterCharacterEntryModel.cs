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
using KHSave.LibFf7Remake.Chunks;
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class ChapterCharacterEntryModel :
        BaseNotifyPropertyChanged
    {
        private readonly ChunkChapter _chapter;
        private readonly int _characterIndex;

        public ChapterCharacterEntryModel(ChunkChapter chapter, int characterIndex)
        {
            _chapter = chapter;
            _characterIndex = characterIndex;
            StatusTypes = new KhEnumListModel<CharacterStatusType>(() => default, x => { });
            TeleportCommand = new RelayCommand(_ =>
            {
                new Views.TeleportWindow(this).ShowDialog();
            });
        }

        private Vector3f Position => _chapter.Positions[_characterIndex];
        private Vector3f Rotation => _chapter.Rotations[_characterIndex];

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public KhEnumListModel<CharacterStatusType> StatusTypes { get; }
        public RelayCommand TeleportCommand { get; }

        public string Name => InfoAttribute.GetInfo((CharacterType)_characterIndex);
        public string TextCoordinates => $"POS({PosX:F0}, {PosY:F0}, {PosZ:F0})";
        public CharacterStatusType Status
        { get => _chapter.CharacterStatus[_characterIndex]; set => _chapter.CharacterStatus[_characterIndex] = value; }

        public float PosX { get => Position.X; set { Position.X = value; OnPropertyChanged(); OnPropertyChanged(nameof(TextCoordinates)); } }
        public float PosY { get => Position.Y; set { Position.Y = value; OnPropertyChanged(); OnPropertyChanged(nameof(TextCoordinates)); } }
        public float PosZ { get => Position.Z; set { Position.Z = value; OnPropertyChanged(); OnPropertyChanged(nameof(TextCoordinates)); } }
        public float RotX { get => Rotation.X; set { Rotation.X = value; OnPropertyChanged(); OnPropertyChanged(nameof(TextCoordinates)); } }
        public float RotY { get => Rotation.Y; set { Rotation.Y = value; OnPropertyChanged(); OnPropertyChanged(nameof(TextCoordinates)); } }
        public float RotZ { get => Rotation.Z; set { Rotation.Z = value; OnPropertyChanged(); OnPropertyChanged(nameof(TextCoordinates)); } }
    }
}
