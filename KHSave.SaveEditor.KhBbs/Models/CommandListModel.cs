using KHSave.Attributes;
using KHSave.LibBbs.Models;
using KHSave.LibBbs.Types;
using KHSave.SaveEditor.Common.Services;
using System.Windows.Media;
using Xe.Tools;

namespace KHSave.SaveEditor.KhBbs.Models
{
    public class CommandListModel : BaseNotifyPropertyChanged
    {
        private readonly int _index;
        private readonly Command[] _commands;

        public CommandListModel(int index, Command[] commands)
        {
            _index = index;
            _commands = commands;
        }

        public string Name => InfoAttribute.GetInfo(_commands[_index].Id);
        public ImageSource Icon => IconService.Icon(_commands[_index].Id);
        //public CommandType CommandType => _commands[_index].Id;
        
    }
}
