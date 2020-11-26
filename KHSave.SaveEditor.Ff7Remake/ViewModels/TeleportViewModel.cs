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

using KHSave.LibFf7Remake;
using KHSave.SaveEditor.Ff7Remake.Data;
using KHSave.SaveEditor.Ff7Remake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Xe.Tools;
using Xe.Tools.Wpf.Commands;

namespace KHSave.SaveEditor.Ff7Remake.ViewModels
{
    public class TeleportViewModel : BaseNotifyPropertyChanged
    {
        private readonly ChapterCharacterEntryModel _entry;
        private int _selectedIndex;
        private List<Location> _locations;

        public Uri AddLocationRequestUrl => new Uri(
            $"https://github.com/Xeeynamo/KH3SaveEditor/issues/new?assignees=Xeeynamo&labels=ff7r-location&template=ff7r-teleport-coordinates-request.md&title=FF7+Remake+new+location+request+" +
            $"({_entry.PosX},{_entry.PosY},{_entry.PosZ})");

        public Uri SourceCodeUrl => new Uri("https://github.com/Xeeynamo/KH3SaveEditor/blob/master/KHSave.LibFf7Remake/Presets.cs");

        public TeleportViewModel(ChapterCharacterEntryModel entry)
        {
            _entry = entry;
            _locations = LocationsPreset.GetLocationsOffline();
            FetchStatusText = "Fetching updated list of locations from internet...";

            Task.Run(async () =>
            {
                List<Location> locations = null;
                string fetchStatusText = "<this is a bug>";
                try
                {
                    locations = await LocationsPreset.FetchLocations();
                    fetchStatusText = "Got most up-to-date list from internet.";
                }
                catch
                {
                    fetchStatusText = "There was an error while retrieving the updated location list.";
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (locations != null)
                    {
                        _locations = locations;
                        OnPropertyChanged(nameof(Locations));
                    }

                    FetchStatusText = fetchStatusText;
                    OnPropertyChanged(nameof(FetchStatusText));
                });
            });

            OkCommand = new RelayCommand(_ =>
            {
                if (SelectedIndex < 0 || SelectedIndex >= _locations.Count)
                    return;

                var location = _locations[SelectedIndex];
                _entry.PosX = location.PositionX;
                _entry.PosY = location.PositionY;
                _entry.PosZ = location.PositionZ;

                Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive)?.Close();
            }, _ => SelectedIndex >= 0);
        }

        public RelayCommand OkCommand { get; }

        public object Locations => _locations.Select(x => new
        {
            x.Chapter,
            IsOutOfBounds = x.OutOfBounds,
            x.Description,
            Coordinates = $"{x.PositionX:F0}, {x.PositionY:F0}, {x.PositionZ:F0}"
        });

        public string FetchStatusText { get; private set; }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(OkCommand));
            }
        }
    }
}
