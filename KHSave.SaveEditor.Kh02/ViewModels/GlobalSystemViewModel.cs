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

using KHSave.Trssv;

namespace KHSave.SaveEditor.Kh02.ViewModels
{
    public class GlobalSystemViewModel
    {
        private readonly SaveKh02 save;

        public GlobalSystemViewModel(SaveKh02 save)
        {
            this.save = save;
        }

        public bool IsVibrationEnable { get => save.IsVibrationEnable; set => save.IsVibrationEnable = value; }
        public bool InvertCameraVertical { get => save.InvertCameraVertical; set => save.InvertCameraVertical = value; }
        public bool InvertCameraHorizontal { get => save.InvertCameraHorizontal; set => save.InvertCameraHorizontal = value; }
        public bool IsMapVisible { get => save.IsMapVisible; set => save.IsMapVisible = value; }
        public bool IsSubtitlesVisible { get => save.IsSubtitlesVisible; set => save.IsSubtitlesVisible = value; }
        public bool Unk10_Bit5 { get => save.Unk10_Bit5; set => save.Unk10_Bit5 = value; }
        public bool CanEarnExp { get => save.CanEarnExp; set => save.CanEarnExp = value; }

        public int CameraSpeed { get => save.CameraSpeed; set => save.CameraSpeed = value; }
        public int Brightness { get => save.Brightness; set => save.Brightness = value; }
        public int TheaterModeWatched { get => save.TheaterModeWatched; set => save.TheaterModeWatched = value; }
        public int TheaterMode { get => save.TheaterMode; set => save.TheaterMode = value; }
    }
}

