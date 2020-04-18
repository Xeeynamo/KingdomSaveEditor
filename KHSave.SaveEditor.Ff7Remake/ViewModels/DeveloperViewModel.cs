using KHSave.LibFf7Remake;
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
        private int _absoluteOffset;

        public DeveloperViewModel(SaveFf7Remake save) :
            base(save.Chunks.Select((x, i) => new ChunkEntryModel(x, i)))
        {
            _save = save;
        }

        public Visibility EntryVisible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EntryNotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        public string AbsoluteOffset
        {
            get => $"0x{_absoluteOffset:X}";
            set
            {
                const int HeaderLength = 0x30;
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
            throw new System.NotImplementedException();
    }
}
