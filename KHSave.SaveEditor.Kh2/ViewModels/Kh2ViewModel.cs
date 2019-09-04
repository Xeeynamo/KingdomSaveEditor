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

using KHSave.Lib2;
using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Exceptions;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.SaveEditor.Kh2.ViewModels
{
    public class Kh2ViewModel : IRefreshUi, IWriteToStream
    {
        private readonly SaveKh2.SaveFinalMix save;

        public Kh2ViewModel(Stream stream)
        {
            switch (SaveKh2.GetGameVersion(stream))
            {
                case GameVersion.Japanese:
                    throw new SaveNotSupportedException("Japanese save file is not yet supported.");
                case GameVersion.American:
                    throw new SaveNotSupportedException("American or European save file is not yet supported.");
                case GameVersion.FinalMix:
                    save = BinaryMapping.ReadObject<SaveKh2.SaveFinalMix>(stream);
                    break;
                case null:
                    throw new SaveNotSupportedException("An invalid version has been specified.");
                default:
                    throw new SaveNotSupportedException("The version has been recognized but it is not supported.");
            }

            RefreshUi();
        }

        public SystemViewModel System { get; private set; }
        public PlayersViewModel Players { get; private set; }

        public void RefreshUi()
        {
            System = new SystemViewModel(save);
            Players = new PlayersViewModel(save);
        }

        public void WriteToStream(Stream stream)
        {
            BinaryMapping.WriteObject(stream, save);
        }
    }
}
