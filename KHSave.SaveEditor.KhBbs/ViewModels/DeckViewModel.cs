using KHSave.LibBbs.Models;
using KHSave.SaveEditor.KhBbs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xe.Tools;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class DeckViewModel : BaseNotifyPropertyChanged
    {
        private Deck deck;

        public DeckViewModel(Deck deck, Command[] commandList)
        {
            this.deck = deck;
            CommandList = commandList.Select((_, i) => new CommandListModel(i, commandList)).ToList();
        }

        public string Name => Encoding.GetEncoding(932).GetString(deck.Name); //shift-jis, does this also apply to other versions?

        public ushort Bc1 { get => deck.BattleCommands[0].Id; set => deck.BattleCommands[0].Id = value; }
        public ushort Bc2 { get => deck.BattleCommands[1].Id; set => deck.BattleCommands[1].Id = value; }
        public ushort Bc3 { get => deck.BattleCommands[2].Id; set => deck.BattleCommands[2].Id = value; }
        public ushort Bc4 { get => deck.BattleCommands[3].Id; set => deck.BattleCommands[3].Id = value; }
        public ushort Bc5 { get => deck.BattleCommands[4].Id; set => deck.BattleCommands[4].Id = value; }
        public ushort Bc6 { get => deck.BattleCommands[5].Id; set => deck.BattleCommands[5].Id = value; }
        public ushort Bc7 { get => deck.BattleCommands[6].Id; set => deck.BattleCommands[6].Id = value; }
        public ushort Bc8 { get => deck.BattleCommands[7].Id; set => deck.BattleCommands[7].Id = value; }

        public ushort Ac1 { get => deck.ActionCommands[0].Id; set => deck.ActionCommands[0].Id = value; }
        public ushort Ac2 { get => deck.ActionCommands[1].Id; set => deck.ActionCommands[1].Id = value; }
        public ushort Ac3 { get => deck.ActionCommands[2].Id; set => deck.ActionCommands[2].Id = value; }
        public ushort Ac4 { get => deck.ActionCommands[3].Id; set => deck.ActionCommands[3].Id = value; }
        public ushort Ac5 { get => deck.ActionCommands[4].Id; set => deck.ActionCommands[4].Id = value; }
        public ushort Ac6 { get => deck.ActionCommands[5].Id; set => deck.ActionCommands[5].Id = value; }
        public ushort Ac7 { get => deck.ActionCommands[6].Id; set => deck.ActionCommands[6].Id = value; }
        public ushort Ac8 { get => deck.ActionCommands[7].Id; set => deck.ActionCommands[7].Id = value; }
        public ushort Ac9 { get => deck.ActionCommands[8].Id; set => deck.ActionCommands[8].Id = value; }
        public ushort Ac10 { get => deck.ActionCommands[9].Id; set => deck.ActionCommands[9].Id = value; }

        public ushort Shotlock { get => deck.Shotlock.Id; set => deck.Shotlock.Id = value; }

        public List<CommandListModel> CommandList { get; set; }
    }
}
