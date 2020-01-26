/*
    Kingdom Hearts Save Editor
    Copyright (C) 2019 Luciano Ciccariello

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

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using KHSave.Lib3.Models;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Kh3.Models;
using System;
using System.Collections.ObjectModel;

namespace KHSave.SaveEditor.Kh3.ViewModels
{
    public class InventoryViewModel : GenericListModel<InventoryItemViewModel>
    {
        private string searchTerm;

        public RelayCommand SelectAllCommand { get; }
        public RelayCommand Research0Command { get; }
        public RelayCommand Research1Command { get; }
        public RelayCommand Research2Command { get; }
        public RelayCommand Research3Command { get; }
        public RelayCommand Research4Command { get; }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;

        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                searchTerm = value;
                if (string.IsNullOrWhiteSpace(searchTerm))
                    Filter();
                else
                    Filter(x => FilterInventoryAdvanced(value.Trim(), x));
            }
        }

        public IEnumerable<InventoryItemViewModel> SelectedItems => Items.Where(x => x.IsSelected);

        public InventoryViewModel(IEnumerable<InventoryEntry> list) :
            this(list.Select((item, index) => new InventoryItemViewModel(item, index)))
        { }

        public InventoryViewModel(IEnumerable<InventoryItemViewModel> list) :
            base(list.Where(x => Global.CanDisplay(x.Value)))
        {
            Research0Command = new RelayCommand(o => DoResearch(500), x => true);
            Research1Command = new RelayCommand(o => DoResearch(600), x => true);
            Research2Command = new RelayCommand(o => DoResearch(700), x => true);
            Research3Command = new RelayCommand(o => DoResearch(800), x => true);
            Research4Command = new RelayCommand(o => DoResearch(900), x => true);

            SelectAllCommand = new RelayCommand(o =>
            {
                foreach (var item in Items)
                    item.IsSelected = true;
            }, x => true);
        }

        public int? SelectedItemCount
        {
            get => GetForAll(SelectedItems, x => x.Count, out var count) ? count : (int?)null;
            set => SetForAll(SelectedItems, (x, v) => x.Count = v ?? 0, value);
        }

        public bool? SelectedItemFlagObtained
        {
            get => GetForAll(SelectedItems, x => x.Obtained, out var flag) ? flag : (bool?)null;
            set => SetForAll(SelectedItems, (x, v) => x.Obtained = v ?? false, value);
        }

        public bool? SelectedItemFlagUnseen
        {
            get => GetForAll(SelectedItems, x => x.Unseen, out var flag) ? flag : (bool?)null;
            set => SetForAll(SelectedItems, (x, v) => x.Unseen = v ?? false, value);
        }

        public bool? SelectedItemFlagShop
        {
            get => GetForAll(SelectedItems, x => x.ShopVisible, out var flag) ? flag : (bool?)null;
            set
            {
                SetForAll(SelectedItems, (x, v) => x.ShopVisible = v ?? false, value);
                OnPropertyChanged(nameof(SelectedItemFlag2));
                OnPropertyChanged(nameof(SelectedItemFlag3));
            }
        }

        public bool? SelectedItemFlag2
        {
            get => GetForAll(SelectedItems, x => x.ShopSeen, out var flag) ? flag : (bool?)null;
            set
            {
                SetForAll(SelectedItems, (x, v) => x.ShopSeen = v ?? false, value);
                OnPropertyChanged(nameof(SelectedItemFlagShop));
            }
        }

        public bool? SelectedItemFlag3
        {
            get => GetForAll(SelectedItems, x => x.Flag3, out var flag) ? flag : (bool?)null;
            set
            {
                SetForAll(SelectedItems, (x, v) => x.Flag3 = v ?? false, value);
                OnPropertyChanged(nameof(SelectedItemFlagShop));
            }
        }

        public bool? SelectedItemFlag4
        {
            get => GetForAll(SelectedItems, x => x.Flag4, out var flag) ? flag : (bool?)null;
            set => SetForAll(SelectedItems, (x, v) => x.Flag4 = v ?? false, value);
        }

        public bool? SelectedItemFlag5
        {
            get => GetForAll(SelectedItems, x => x.Flag5, out var flag) ? flag : (bool?)null;
            set => SetForAll(SelectedItems, (x, v) => x.Flag5 = v ?? false, value);
        }

        public bool? SelectedItemFlag6
        {
            get => GetForAll(SelectedItems, x => x.Flag6, out var flag) ? flag : (bool?)null;
            set => SetForAll(SelectedItems, (x, v) => x.Flag6 = v ?? false, value);
        }

        public bool? SelectedItemFlag7
        {
            get => GetForAll(SelectedItems, x => x.Flag7, out var flag) ? flag : (bool?)null;
            set => SetForAll(SelectedItems, (x, v) => x.Flag7 = v ?? false, value);
        }

        public void ChangeSelectedItems()
        {
            OnPropertyChanged(nameof(SelectedItemCount));
            OnPropertyChanged(nameof(SelectedItemFlagObtained));
            OnPropertyChanged(nameof(SelectedItemFlagUnseen));
            OnPropertyChanged(nameof(SelectedItemFlagShop));
            OnPropertyChanged(nameof(SelectedItemFlag2));
            OnPropertyChanged(nameof(SelectedItemFlag3));
            OnPropertyChanged(nameof(SelectedItemFlag4));
            OnPropertyChanged(nameof(SelectedItemFlag5));
            OnPropertyChanged(nameof(SelectedItemFlag6));
            OnPropertyChanged(nameof(SelectedItemFlag7));
        }

        private void DoResearch(int startIndex, int count = 100)
        {
            for (var i = 0; i < count; i++)
            {
                Items[startIndex + i].Count = i + 1;
            }
        }

        private static bool GetForAll<TModel, TValue>(IEnumerable<TModel> items, Func<TModel, TValue> getter, out TValue value)
        {
            if (!(items is List<TModel> list)) // speed hack
                list = items.ToList();

            if (list.Count == 0)
            {
                value = default(TValue);
                return false;
            }

            value = getter(list[0]);

            if (list.Count == 1)
                return true;

            var myValue = value;
            return list.All(x => getter(x).GetHashCode() == myValue.GetHashCode());
        }

        private static void SetForAll<TModel, TValue>(IEnumerable<TModel> items, Action<TModel, TValue> setter, TValue value)
        {
            foreach (var item in items)
                setter(item, value);
        }

        private static bool FilterInventoryAdvanced(string value, InventoryItemViewModel x) =>
            value
            .Split(new char[] { ',', ';' })
            .Any(subString => FilterInventory(subString, x));

        private static bool FilterInventory(string value, InventoryItemViewModel x) =>
            FilterByName(value, x) ||
            FilterByCountWithOperator(value, x) ||
            FilterByFlag(value, x);

        private static bool FilterByName(string value, InventoryItemViewModel x)
        {
            return x.Name.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        private static bool FilterByCountWithOperator(string value, InventoryItemViewModel x)
        {
            if (value.Length < 2)
                return false;

            var op = value[0];
            string subValue = value.Substring(1).Trim();
            if (op == '>')
                return value.Length < 2 || FilterByCountGreater(subValue, x);
            else if (op == '<')
                return value.Length < 2 || FilterByCountLess(subValue, x);
            else if (op == '=')
                return value.Length < 2 || FilterByCount(subValue, x);

            return false;
        }

        private static bool FilterByCount(string value, InventoryItemViewModel x)
        {
            if (!int.TryParse(value, out var count))
                return false;

            return x.Count == count;
        }

        private static bool FilterByCountGreater(string value, InventoryItemViewModel x)
        {
            if (!int.TryParse(value, out var count))
                return false;

            return x.Count > count;
        }

        private static bool FilterByCountLess(string value, InventoryItemViewModel x)
        {
            if (!int.TryParse(value, out var count))
                return false;

            return x.Count < count;
        }

        private static bool FilterByFlag(string value, InventoryItemViewModel x)
        {
            if (value.Length == 0)
                return false;

            var expectedValue = value[0] != '!';

            if (ContainsWord(value, "unseen"))
                return x.Unseen == expectedValue;
            if (ContainsWord(value, "obtained"))
                return x.Obtained == expectedValue;
            if (ContainsWord(value, "shop"))
                return x.ShopVisible == expectedValue;

            return false;
        }

        private static bool ContainsWord(string value, string contains) =>
            contains.IndexOf(value) >= 0 || value.IndexOf(contains) >= 0;

        protected override InventoryItemViewModel OnNewItem()
        {
            throw new System.NotImplementedException();
        }
    }
}
