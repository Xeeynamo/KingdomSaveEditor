using KHSave.Attributes;
using KHSave.Lib2;
using KHSave.Lib2.Types;
using KHSave.SaveEditor.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class WorldViewModel : BaseNotifyPropertyChanged
    {
        private readonly ISaveKh2 _save;
        private readonly WorldType _world;

        public WorldViewModel(ISaveKh2 save, int index)
        {
            _save = save;
            _world = (WorldType)index;
            Pc0 = new KhEnumListModel<PlayableCharacterType>(
                () => save.WorldPartyMembers[index].PlayableCharacter,
                x => save.WorldPartyMembers[index].PlayableCharacter = x);
            Pc1 = new KhEnumListModel<PlayableCharacterType>(
                () => save.WorldPartyMembers[index].CompanionCharacter1,
                x => save.WorldPartyMembers[index].CompanionCharacter1 = x);
            Pc2 = new KhEnumListModel<PlayableCharacterType>(
                () => save.WorldPartyMembers[index].CompanionCharacter2,
                x => save.WorldPartyMembers[index].CompanionCharacter2 = x);
            Pc3 = new KhEnumListModel<PlayableCharacterType>(
                () => save.WorldPartyMembers[index].CompanionCharacter3,
                x => save.WorldPartyMembers[index].CompanionCharacter3 = x);
        }

        public string Name => WorldAttribute.GetWorldId(_world);

        public KhEnumListModel<PlayableCharacterType> Pc0 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc1 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc2 { get; }
        public KhEnumListModel<PlayableCharacterType> Pc3 { get; }
    }

    public class WorldsViewModel : GenericListModel<WorldViewModel>
    {
        public WorldsViewModel(ISaveKh2 save) :
            this(Enumerable.Range(0, Constants.WorldCount).Select(i => new WorldViewModel(save, i)))
        { }

        public WorldsViewModel(IEnumerable<WorldViewModel> list) :
            base(list)
        { }

        public Visibility Visible => IsItemSelected ? Visibility.Visible : Visibility.Collapsed;
        public Visibility NotVisible => !IsItemSelected ? Visibility.Visible : Visibility.Collapsed;

        protected override void OnSelectedItem(WorldViewModel item)
        {
            base.OnSelectedItem(item);
            OnPropertyChanged(nameof(Visible));
            OnPropertyChanged(nameof(NotVisible));
        }

        protected override WorldViewModel OnNewItem()
        {
            throw new System.NotImplementedException();
        }
    }
}
