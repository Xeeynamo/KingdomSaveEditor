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
using KHSave.LibFf7Remake.Chunks;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Ff7Remake.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class DeveloperViewModel : GenericListModel<ChunkEntryModel>
    {
        private readonly SaveFf7Remake _save;
        private readonly IRefreshUi _refreshUi;
        private int _absoluteOffset;

        public DeveloperViewModel(SaveFf7Remake save, IRefreshUi refreshUi) :
            base(save.Chunks.Select((x, i) => new ChunkEntryModel(save, refreshUi, x, i)))
        {
            _save = save;
            _refreshUi = refreshUi;
        }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        public string AbsoluteOffset
        {
            get => $"0x{_absoluteOffset:X}";
            set
            {
                const int HeaderLength = Chunk.TotalHeaderLength;
                bool isHex = value.Length > 2 && value[0] == '0' && value[1] == 'x';
                bool successful;
                if (isHex)
                    successful = int.TryParse(value.Substring(2), NumberStyles.HexNumber, null, out _absoluteOffset);
                else
                    successful = int.TryParse(value, out _absoluteOffset);

                if (!successful)
                    throw new FormatException("Not a decimal or hex string");


                ChunkId = 0;
                ChunkOffset = _absoluteOffset;
                var prevChunkOffset = 0;
                foreach (var chunk in _save.Chunks)
                {
                    if (ChunkOffset < chunk.Header.NextChunkOffset)
                    {
                        ChunkOffset -= prevChunkOffset + HeaderLength;
                        break;
                    }

                    ChunkId++;
                    prevChunkOffset = chunk.Header.NextChunkOffset;
                }

                OnPropertyChanged(nameof(ChunkId));
                OnPropertyChanged(nameof(ChunkOffset));
            }
        }

        public int ChunkId { get; private set; }
        public int ChunkOffset { get; private set; }

        protected override void OnSelectedItem(ChunkEntryModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(EntryVisible));
            OnPropertyChanged(nameof(EntryNotVisible));
        }

        protected override ChunkEntryModel OnNewItem() =>
            throw new NotImplementedException();
    }
}
