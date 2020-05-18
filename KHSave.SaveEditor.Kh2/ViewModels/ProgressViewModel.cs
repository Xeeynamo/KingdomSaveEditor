using KHSave.Lib2;
using KHSave.Lib2.Models;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Kh2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools.Wpf.Commands;
using Xe.Tools.Wpf.Models;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class ProgressViewModel : GenericListModel<ProgressModel>
    {
        private string _searchTerm;

        public ProgressViewModel(Progress[] progresses) :
            base(GetProgressModels(progresses))
        {
            SetAllCommand = new RelayCommand(_ =>
            {
                foreach (var item in Items)
                    item.Done = true;
            });
            ResetAllCommand = new RelayCommand(_ =>
            {
                foreach (var item in Items)
                    item.Done = false;
            });
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                Filter(items => SearchEngine.Filter(_searchTerm, items, AdditionalFilters).OrderBy(x => (uint)x.Flag));
            }
        }

        private bool AdditionalFilters(string searchTerm, ProgressModel item) =>
            item.World.ToLower().IndexOf(searchTerm.ToLower()) >= 0;

        public RelayCommand SetAllCommand { get; }
        public RelayCommand ResetAllCommand { get; }

        private static IEnumerable<ProgressModel> GetProgressModels(Progress[] progresses)
        {
            return Constants.Progress
                .Select(x => new ProgressModel(x.Key / 1024, progresses[x.Key / 1024], x.Key));
        }
    }
}
