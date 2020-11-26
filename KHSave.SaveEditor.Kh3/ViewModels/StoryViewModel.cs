/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using KHSave.Attributes;
using KHSave.SaveEditor.Common;
using KHSave.Lib3.Types;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Models;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;
using KHSave.Lib3;
using KHSave.Lib3.Presets;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
    public class StoryViewModel : GenericListModel<StoryEntryModel>
    {
        public StoryViewModel(ISaveKh3 save) :
            this(save.Storyflags)
        {
        }

        public StoryViewModel(List<int> storyflags) :
            base(storyflags.Select((_, index) => new StoryEntryModel(storyflags, index)))
        {

        }

        protected override StoryEntryModel OnNewItem()
        {
            throw new System.NotImplementedException();
        }
    }

    public class StoryCommand : RelayCommand
    {
        public StoryCommand(
            ISaveKh3 save,
            string name,
            string map,
            Dictionary<StoryFlagType, int> flags,
            bool zeroEverything = false)
            : base(x =>
            {
                if (!ThrowConfirmationMessage(name))
                    return;

                if (!string.IsNullOrEmpty(map))
                {
                    save.MapPath = map;
                    save.MapSpawn = "default";
                }

                if (zeroEverything)
                {
                    for (var i = 0; i < save.Storyflags.Count; i++)
                    {
                        save.Storyflags[i] = 0;
                    }
                }

                for (var i = 0; i < save.Storyflags.Count; i++)
                {
                    if (flags.TryGetValue((StoryFlagType)i, out var newFlag))
                    {
                        save.Storyflags[i] = newFlag;
                    }
                }
            })
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString() => Name;

        private static bool ThrowConfirmationMessage(string name)
        {
            var response = MessageBox.Show(
                "You are modifying the progress of the story.\n" +
                "This technique it is not 100% save and you could incur\n" +
                "in some glitches or infinite black screern during your run.\n" +
                $"Do you want to apply the change '{name}'?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            return response == MessageBoxResult.Yes;
        }
    }

    public class StoryEntryModel : BaseNotifyPropertyChanged
    {
        private readonly List<int> storyFlag;
        private readonly int index;

        public GenericListModel<EnumItemModel<int>> Preset { get; }

        public StoryEntryModel(List<int> storyFlag, int index)
        {
            this.storyFlag = storyFlag;
            this.index = index;

            if (Presets.STORY.TryGetValue((StoryFlagType)index, out var preset))
            {
                Preset = new StoryPresetModel(preset);
            }
        }

        public string Name => InfoAttribute.GetInfo((StoryFlagType)index) ?? $"{index:X02}";

        public int Value
        {
            get => storyFlag[index];
            set
            {
                storyFlag[index] = value;
                OnPropertyChanged(nameof(Value));
            }
        }
    }

    public class StoryPresetModel : GenericListModel<EnumItemModel<int>>
    {
        public StoryPresetModel(Dictionary<int, string> preset) :
            base(preset.Select(x => new EnumItemModel<int>
            {
                Value = (int)x.Key,
                Name = x.Value
            }))
        { }

        protected override EnumItemModel<int> OnNewItem()
        {
            throw new System.NotImplementedException();
        }
    }
}
