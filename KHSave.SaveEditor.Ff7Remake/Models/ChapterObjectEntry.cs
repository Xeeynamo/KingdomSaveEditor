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

using KHSave.LibFf7Remake.Models;
using System.Collections.Generic;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class ChapterObjectEntry : BaseNotifyPropertyChanged
    {
        private readonly ChapterObject _chapterObject;

        public ChapterObjectEntry(ChapterObject chapterObject, IEnumerable<ChapterObject> siblingObjects, Vector3f cloudPosition)
        {
            _chapterObject = chapterObject;

            DebugTeleportToCloudCommand = new RelayCommand(_ =>
            {
                chapterObject.PositionX = cloudPosition.X;
                chapterObject.PositionY = cloudPosition.Y;
                chapterObject.PositionZ = cloudPosition.Z;
                OnAllPropertiesChanged();
            });
            DebugTeleportToObjectCommand = new RelayCommand(_ =>
            {
                foreach (var obj in siblingObjects)
                {
                    obj.PositionX = chapterObject.PositionX;
                    obj.PositionY = chapterObject.PositionY;
                    obj.PositionZ = chapterObject.PositionZ;
                    OnAllPropertiesChanged();
                }
            });
            DebugIdRandomnessCommand = new RelayCommand(_ =>
            {
                foreach (var obj in siblingObjects)
                {
                    obj.Index = chapterObject.Index;
                    OnAllPropertiesChanged();
                }
            });
        }

        public RelayCommand DebugTeleportToCloudCommand { get; }
        public RelayCommand DebugCloudToObjectCommand { get; }
        public RelayCommand DebugTeleportToObjectCommand { get; }
        public RelayCommand DebugIdRandomnessCommand { get; }

        public string Name => ToString();

        public int Index { get => _chapterObject.Index; set { _chapterObject.Index = value; OnPropertyChanged(nameof(Name)); } }

        public float Unknown04 { get => _chapterObject.Unknown04; set { _chapterObject.Unknown04 = value; OnPropertyChanged((nameof(Name))); } }
        public int Unknown08 { get => _chapterObject.Unknown08; set { _chapterObject.Unknown08 = value; OnPropertyChanged((nameof(Name))); } }
        public float Unknown0c { get => _chapterObject.Unknown0c; set { _chapterObject.Unknown0c = value; OnPropertyChanged((nameof(Name))); } }
        public float PositionX { get => _chapterObject.PositionX; set { _chapterObject.PositionX = value; OnPropertyChanged((nameof(Name))); } }
        public float PositionY { get => _chapterObject.PositionY; set { _chapterObject.PositionY = value; OnPropertyChanged((nameof(Name))); } }
        public float PositionZ { get => _chapterObject.PositionZ; set { _chapterObject.PositionZ = value; OnPropertyChanged((nameof(Name))); } }
        public float Rotation { get => _chapterObject.Rotation; set { _chapterObject.Rotation = value; OnPropertyChanged((nameof(Name))); } }

        public override string ToString() => _chapterObject.ToString();
    }
}
