using KHSave.LibBbs.Models;
using System.Text;
using Xe.Tools;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class DeckViewModel : BaseNotifyPropertyChanged
    {
        private Deck deck;

        public DeckViewModel(Deck deck, CommandListViewModel commandList)
        {
            this.deck = deck;
            CommandList = commandList;
        }

        public CommandListViewModel CommandList { get; set; }

        public string Name => Encoding.GetEncoding(932).GetString(deck.Name); //shift-jis, seems to work in european saves as well

        public short BattleCommand1 { get => GetValue(deck.BattleCommands[0].Id); set => deck.BattleCommands[0].Id = (ushort)value; }
        public short BattleCommand2 { get => GetValue(deck.BattleCommands[1].Id); set => deck.BattleCommands[1].Id = (ushort)value; }
        public short BattleCommand3 { get => GetValue(deck.BattleCommands[2].Id); set => deck.BattleCommands[2].Id = (ushort)value; }
        public short BattleCommand4 { get => GetValue(deck.BattleCommands[3].Id); set => deck.BattleCommands[3].Id = (ushort)value; }
        public short BattleCommand5 { get => GetValue(deck.BattleCommands[4].Id); set => deck.BattleCommands[4].Id = (ushort)value; }
        public short BattleCommand6 { get => GetValue(deck.BattleCommands[5].Id); set => deck.BattleCommands[5].Id = (ushort)value; }
        public short BattleCommand7 { get => GetValue(deck.BattleCommands[6].Id); set => deck.BattleCommands[6].Id = (ushort)value; }
        public short BattleCommand8 { get => GetValue(deck.BattleCommands[7].Id); set => deck.BattleCommands[7].Id = (ushort)value; }

        public short ActionCommand1 { get => GetValue(deck.ActionCommands[0].Id); set => deck.ActionCommands[0].Id = (ushort)value; }
        public short ActionCommand2 { get => GetValue(deck.ActionCommands[1].Id); set => deck.ActionCommands[1].Id = (ushort)value; }
        public short ActionCommand3 { get => GetValue(deck.ActionCommands[2].Id); set => deck.ActionCommands[2].Id = (ushort)value; }
        public short ActionCommand4 { get => GetValue(deck.ActionCommands[3].Id); set => deck.ActionCommands[3].Id = (ushort)value; }
        public short ActionCommand5 { get => GetValue(deck.ActionCommands[4].Id); set => deck.ActionCommands[4].Id = (ushort)value; }
        public short ActionCommand6 { get => GetValue(deck.ActionCommands[5].Id); set => deck.ActionCommands[5].Id = (ushort)value; }
        public short ActionCommand7 { get => GetValue(deck.ActionCommands[6].Id); set => deck.ActionCommands[6].Id = (ushort)value; }
        public short ActionCommand8 { get => GetValue(deck.ActionCommands[7].Id); set => deck.ActionCommands[7].Id = (ushort)value; }
        public short ActionCommand9 { get => GetValue(deck.ActionCommands[8].Id); set => deck.ActionCommands[8].Id = (ushort)value; }
        public short ActionCommand10 { get => GetValue(deck.ActionCommands[9].Id); set => deck.ActionCommands[9].Id = (ushort)value; }

        public short Shotlock { get => GetValue(deck.Shotlock.Id); set => deck.Shotlock.Id = (ushort)value; }

        private short GetValue(ushort value)
        {
            if (value == 0xffff)
                return -1;
            else return (short)value;
        }
    }
}
