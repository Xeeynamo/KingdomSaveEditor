using KHSave.Lib2;
using KHSave.SaveEditor.Kh2.Models;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class RoomVisitedViewModel : BaseNotifyPropertyChanged
    {
        public class RoomVisitedEntry
        {
            private readonly RoomModel _roomModel;
            private readonly byte[] _rooms;
            private readonly int _index;

            internal RoomVisitedEntry(RoomModel roomModel, byte[] rooms, int index)
            {
                _roomModel = roomModel;
                _rooms = rooms;
                _index = index;
            }

            public string Name => _roomModel.ToString();

            public bool Visited
            {
                get => (_rooms[_index / 8] & (1 << (_index & 7))) != 0;
                set
                {
                    var bit = 1 << (_index & 7);
                    if (value)
                        _rooms[_index / 8] |= (byte)bit;
                    else
                        _rooms[_index / 8] &= (byte)(~bit);
                }
            }
        }
        
        private byte[] _roomVisited;

        public RoomVisitedViewModel(SaveKh2.SaveFinalMix save)
        {
            _roomVisited = save.RoomVisitedFlag;
            Entries = Enumerable.Range(0, save.RoomVisitedFlag.Length * 8)
                .Select(i => new
                {
                    Index = i,
                    Room = Data.GetRoom(i / 64, i & 63)
                })
                .Where(x => x.Room != null)
                .Select(x => new RoomVisitedEntry(x.Room, _roomVisited, x.Index))
                .ToList();
        }

        public List<RoomVisitedEntry> Entries { get; }
    }
}
