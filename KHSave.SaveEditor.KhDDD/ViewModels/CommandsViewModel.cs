using KHSave.Attributes;
using KHSave.LibDDD.Model;
using KHSave.LibDDD.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.KhDDD.Interfaces;
using System;
using System.Linq;
using Xe.Tools;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class CommandsViewModel : GenericListModel<CommandEntryViewModel>
    {
        private string _searchTerm;

        public CommandsViewModel(CommandEntry[] commands, IResourceGetter resourceGetter) :
            base(commands.Select(x => new CommandEntryViewModel(x, resourceGetter)))
        {

        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                Filter(items => SearchEngine.Filter(_searchTerm, items));
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    public class CommandEntryViewModel : BaseNotifyPropertyChanged, SearchEngine.IName, SearchEngine.ICount
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

        public bool IsSoraEquippedDeck1
        {
            get => (_commandEntry.SoraEquipFlags & 1) != 0;
            set
            {
                if (value)
                    _commandEntry.SoraEquipFlags |= 1;
                else
                    _commandEntry.SoraEquipFlags = (byte)(_commandEntry.SoraEquipFlags & ~1);
            }
        }

        public bool IsSoraEquippedDeck2
        {
            get => (_commandEntry.SoraEquipFlags & 2) != 0;
            set
            {
                if (value)
                    _commandEntry.SoraEquipFlags |= 2;
                else
                    _commandEntry.SoraEquipFlags = (byte)(_commandEntry.SoraEquipFlags & ~2);
            }
        }

        public bool IsSoraEquippedDeck3
        {
            get => (_commandEntry.SoraEquipFlags & 4) != 0;
            set
            {
                if (value)
                    _commandEntry.SoraEquipFlags |= 4;
                else
                    _commandEntry.SoraEquipFlags = (byte)(_commandEntry.SoraEquipFlags & ~4);
            }
        }

        public bool IsRikuEquippedDeck1
        {
            get => (_commandEntry.RikuEquipFlags & 1) != 0;
            set
            {
                if (value)
                    _commandEntry.RikuEquipFlags |= 1;
                else
                    _commandEntry.RikuEquipFlags = (byte)(_commandEntry.RikuEquipFlags & ~1);
            }
        }

        public bool IsRikuEquippedDeck2
        {
            get => (_commandEntry.RikuEquipFlags & 2) != 0;
            set
            {
                if (value)
                    _commandEntry.RikuEquipFlags |= 2;
                else
                    _commandEntry.RikuEquipFlags = (byte)(_commandEntry.RikuEquipFlags & ~2);
            }
        }

        public bool IsRikuEquippedDeck3
        {
            get => (_commandEntry.RikuEquipFlags & 4) != 0;
            set
            {
                if (value)
                    _commandEntry.RikuEquipFlags |= 4;
                else
                    _commandEntry.RikuEquipFlags = (byte)(_commandEntry.RikuEquipFlags & ~4);
            }
        }

        public int Count
        {
            get => _commandEntry.Amount;
            set => _commandEntry.Amount = (byte)Math.Min(Math.Max(value, 0), 255);
        }
    }
}
