using KHSave.SaveEditor.Models;
using System.Windows.Media;

namespace KHSave.SaveEditor.ViewModels
{
    public class PatronViewModel
    {
        public PatronViewModel(PatronModel patron)
        {
            Brush = GetColor(patron.Color);
            Name = patron.Name;
        }

        public Brush Brush { get; }

        public string Name { get; }

        private static SolidColorBrush GetColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color) ||
                color[0] != '#')
                return new SolidColorBrush(Colors.Red);

            return new BrushConverter().ConvertFromString(color) as SolidColorBrush;
        }
    }
}
