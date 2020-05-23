using KHSave.Attributes;
using KHSave.LibBbs.Models;
using KHSave.LibBbs.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common.Services;
using System.Windows.Media;
using Xe.Tools;

namespace KHSave.SaveEditor.KhBbs.ViewModels
{
    public class CommandViewModel : BaseNotifyPropertyChanged
    {
        private Command command;

        public CommandViewModel(Command command)
        {
            this.command = command;

            Commands = new KhEnumListModel<CommandType>();
            Abilities = new KhEnumListModel<AbilityType>();

            Id2 = new ItemComboBoxModel<CommandType>(() => command.Id, x => command.Id = x);
            Ability2 = new ItemComboBoxModel<AbilityType>(() => command.Ability, x => command.Ability = x);
        }

        public ImageSource Icon => IconService.Icon(command.Id);

        public string Name => InfoAttribute.GetInfo(command.Id);
        public KhEnumListModel<CommandType> Commands { get; set; }
        public KhEnumListModel<AbilityType> Abilities { get; set; }

        public ItemComboBoxModel<CommandType> Id2 { get; set; }
        public ItemComboBoxModel<AbilityType> Ability2 { get; set; }

        public CommandType Id 
        { 
            get => command.Id;
            set
            {
                command.Id = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ushort Level { get => command.Level; set => command.Level = value; }
        public ushort Experience { get => command.Experience; set => command.Experience = value; }
        public AbilityType Ability { get => command.Ability; set => command.Ability = value; }
        public ushort Flags { get => command.Flags; set => command.Flags = value; }
    }
}
