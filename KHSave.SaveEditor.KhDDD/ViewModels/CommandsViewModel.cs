using KHSave.Attributes;
using KHSave.LibDDD.Model;
using KHSave.LibDDD.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.KhDDD.Interfaces;
using System.Linq;
using Xe.Tools;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class CommandsViewModel : GenericListModel<CommandEntryViewModel>
    {
        public CommandsViewModel(CommandEntry[] commands, IResourceGetter resourceGetter) :
            base(commands.Select(x => new CommandEntryViewModel(x, resourceGetter)))
        {

        }
    }

    public class CommandEntryViewModel : BaseNotifyPropertyChanged
    {
        private readonly CommandEntry _commandEntry;
        private readonly IResourceGetter _resourceGetter;

        public CommandEntryViewModel(CommandEntry commandEntry, IResourceGetter resourceGetter)
        {
            _commandEntry = commandEntry;
            _resourceGetter = resourceGetter;
        }

        public string Name => InfoAttribute.GetInfo(Id);

        public KhEnumListModel<EnumIconTypeModel<EquipmentType>, EquipmentType> Commands => _resourceGetter.Equipments;

        public EquipmentType Id
        {
            get => _commandEntry.Id;
            set
            {
                _commandEntry.Id = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public byte Unk02 { get => _commandEntry.Unk02; set => _commandEntry.Unk02 = value; }

        public byte Unk03 { get => _commandEntry.Unk03; set => _commandEntry.Unk03 = value; }

        public byte Amount { get => _commandEntry.Amount; set => _commandEntry.Amount = value; }
    }
}
