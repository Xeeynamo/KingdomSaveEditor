using KHSave.LibPersona5;
using KHSave.LibPersona5.Types;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Common.Properties;
using KHSave.SaveEditor.Persona5.Interfaces;
using System.IO;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Persona5.ViewModels
{
    public class Persona5MainViewModel : BaseNotifyPropertyChanged,
        IRefreshUi, IOpenStream, IWriteToStream,
        IPersonaList, ISkillList, IEquipmentList
    {
        private const string DefaultTab = "Characters";

        public ISavePersona5 Save { get; private set; }

        public CharactersViewModel Characters { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public SystemViewModel System { get; set; }

        public Visibility SimpleVisibility => Common.Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Common.Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public string CurrentTabId
        {
            get => Settings.Default.LastPersona5Tab ?? DefaultTab;
            set
            {
                Settings.Default.LastPersona5Tab = value;
                Settings.Default.Save();
            }
        }

        public KhEnumListModel<Demon> PersonaList { get; } = new KhEnumListModel<Demon>();
        public KhEnumListModel<EnumIconTypeModel<Skill>, Skill> SkillList { get; } = new KhEnumListModel<EnumIconTypeModel<Skill>, Skill>();
        public KhEnumListModel<EnumIconTypeModel<Equipment>, Equipment> EquipmentList { get; } = new KhEnumListModel<EnumIconTypeModel<Equipment>, Equipment>();

        public void RefreshUi()
        {
            Characters = new CharactersViewModel(Save, this, this, this);
            Inventory = new InventoryViewModel(Save);
            System = new SystemViewModel(Save);

            OnPropertyChanged(nameof(SimpleVisibility));
            OnPropertyChanged(nameof(AdvancedVisibility));
            OnPropertyChanged(nameof(Characters));
            OnPropertyChanged(nameof(Inventory));
        }

        public void OpenStream(Stream stream)
        {
            Save = SavePersona5.Read(stream);
            RefreshUi();
        }

        public void WriteToStream(Stream stream) =>
            SavePersona5.Write(stream, Save);
    }
}
