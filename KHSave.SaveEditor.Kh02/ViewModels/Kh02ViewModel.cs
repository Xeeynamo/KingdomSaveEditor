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

using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Kh02.Models;
using KHSave.Trssv;
using System.IO;
using Xe.Tools;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh02.ViewModels
{
    public class Kh02ViewModel : BaseNotifyPropertyChanged, IRefreshUi, IWriteToStream
    {
        private SlotViewModel selectedSlot;

        public SaveKh02 Save { get; }

        public GlobalSystemViewModel GlobalSystem { get; set; }

        public GenericListModel<SlotViewModel> Slots { get; set; }

        public SlotViewModel SelectedSlot
        {
            get => selectedSlot;
            set
            {
                selectedSlot = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSlotSelected));
            }
        }

        public bool IsSlotSelected => SelectedSlot != null;

        public Kh02ViewModel(Stream stream)
        {
            Save = SaveKh02.Read(stream);
            Slots = new SlotListModel(Save);
        }

        public void RefreshUi()
        {
            GlobalSystem = new GlobalSystemViewModel(Save);

            OnPropertyChanged(nameof(GlobalSystem));

            var prevSlot = SelectedSlot;
            SelectedSlot = null;
            OnPropertyChanged(nameof(SelectedSlot));
            SelectedSlot = prevSlot;
        }

        public void WriteToStream(Stream stream) => Save.Write(stream);
    }
}
