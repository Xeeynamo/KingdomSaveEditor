using Xe.BinaryMapper;

namespace KHSave.LibBbs.Models
{
    public class Deck
    {
        [Data(Count = 8)] public Command[] BattleCommands { get; set; }
        [Data(Count = 9)] public Command[] ActionCommands { get; set; }
        [Data] public Command Shotlock { get; set; }
        [Data] public Command Unknown { get; set; }
        [Data(Count = 10)] public ushort[] Unk { get; set; }
        [Data(Count = 16)] public byte[] Name { get; set; }
        [Data(Count = 46)] public byte[] Dummy { get; set; }

        public class Command
        {
            [Data] public ushort Id { get; set; }
            [Data] public ushort Unk02 { get; set; }
            [Data] public ushort Unk04 { get; set; }
        }
    }
}
