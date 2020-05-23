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

            Id = new ItemComboBoxModel<CommandType>(() => command.Id, x => { command.Id = x; OnPropertyChanged(nameof(Name)); OnPropertyChanged(nameof(Id)); });
            Ability = new ItemComboBoxModel<AbilityType>(() => command.Ability, x => command.Ability = x);
        }

        public ImageSource Icon => IconService.Icon(command.Id);

        public string Name => InfoAttribute.GetInfo(command.Id);

        public ItemComboBoxModel<CommandType> Id { get; set; }
        public ItemComboBoxModel<AbilityType> Ability { get; set; }

        public ushort Level { get => command.Level; set => command.Level = value; }
        public ushort Experience { get => command.Experience; set => command.Experience = value; }
        public ushort Flags { get => command.Flags; set => command.Flags = value; }
    }
}
