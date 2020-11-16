using KHSave.LibDDD.Model;
using KHSave.LibDDD.Types;
using KHSave.SaveEditor.Common.Models;
using System.Text;
using Xe.Tools;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class DreamEaterViewModel : BaseNotifyPropertyChanged
    {
        private readonly DreamEater dreamEater;

        public DreamEaterViewModel(DreamEater dreamEater)
        {
            this.dreamEater = dreamEater;
            DreamEaterTypes = new KhEnumListModel<DreamEaterType>();
        }
        public DreamEaterType DreamEaterType { get => dreamEater.DreamEaterType; set => dreamEater.DreamEaterType = value; }
        public KhEnumListModel<DreamEaterType> DreamEaterTypes { get; set; }
        public string Name { get => Encoding.GetEncoding(932).GetString(dreamEater.Name); set => dreamEater.Name = Encoding.GetEncoding(932).GetBytes(value); } //shift-jis, is the same for EU save

        public byte Attack { get => dreamEater.Attack; set => dreamEater.Attack = value; }
        public byte Magic { get => dreamEater.Magic; set => dreamEater.Magic = value; }
        public byte Defence { get => dreamEater.Defence; set => dreamEater.Defence = value; }
    }
}
