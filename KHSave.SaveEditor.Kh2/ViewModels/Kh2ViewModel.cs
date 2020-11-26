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

using KHSave.Lib2;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Exceptions;
using System;
using System.IO;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class Kh2ViewModel : BaseNotifyPropertyChanged, IRefreshUi, IOpenStream, IWriteToStream
    {
        private ISaveKh2 save;

        public Kh2ViewModel()
        {
        }

        public SystemViewModel System { get; private set; }
        public InventoryViewModel Inventory { get; private set; }
        public CharactersViewModel Characters { get; private set; }
        public DriveFormsViewModel DriveForms { get; private set; }
        public WorldsViewModel Worlds { get; private set; }
        public RoomVisitedViewModel RoomVisited { get; private set; }
        public ProgressViewModel Progress { get; private set; }

        public void RefreshUi()
        {
            System = new SystemViewModel(save);
            Inventory = new InventoryViewModel(save);
            Characters = new CharactersViewModel(save);
            DriveForms = new DriveFormsViewModel(save);
            Worlds = new WorldsViewModel(save);
            RoomVisited = new RoomVisitedViewModel(save);
            Progress = new ProgressViewModel(save.StoryProgress);

            OnPropertyChanged(nameof(System));
            OnPropertyChanged(nameof(Inventory));
            OnPropertyChanged(nameof(Characters));
            OnPropertyChanged(nameof(Characters));
            OnPropertyChanged(nameof(DriveForms));
            OnPropertyChanged(nameof(Worlds));
            OnPropertyChanged(nameof(RoomVisited));
            OnPropertyChanged(nameof(Progress));
        }

        public void OpenStream(Stream stream)
        {
            try
            {
                save = SaveKh2.Read(stream);
                RefreshUi();
            }
            catch (NotImplementedException ex)
            {
                throw new SaveNotSupportedException(ex.Message);
            }
        }

        public void WriteToStream(Stream stream) => SaveKh2.Write(stream, save);
    }
}
