using Xe.BinaryMapper;

namespace KHSave.LibBbs.Models
{
    public class Deck
    {
        [Data(Count = 8)] public Command[] BattleCommands { get; set; }
        [Data(Count = 10)] public Command[] ActionCommands { get; set; }
        [Data] public Command Shotlock { get; set; }
        [Data(Count = 0x14)] public byte[] Unk72 { get; set; }
        [Data(Count = 16)] public byte[] Name { get; set; }
        [Data(Count = 46)] public byte[] Unk90 { get; set; } //Padding?

        public class Command
        {
            [Data] public ushort Id { get; set; } // Id in CommandList
            [Data] public ushort Unk02 { get; set; }
            [Data] public ushort Unk04 { get; set; }
        }
    }
}
