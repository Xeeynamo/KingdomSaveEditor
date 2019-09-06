using System.Windows.Media;

namespace KHSave.SaveEditor.ViewModels
{
    public class PatronViewModel
    {
        private PatronViewModel(Color color, string name)
        {
            Brush = new SolidColorBrush(color);
            Name = name;
        }

        public Brush Brush { get; }

        public string Name { get; }

        public static PatronViewModel Bronze(string name) =>
            new PatronViewModel(Color.FromRgb(214, 112, 11), name);
        public static PatronViewModel Silver(string name) =>
            new PatronViewModel(Color.FromRgb(166, 166, 166), name);
        public static PatronViewModel Gold(string name) =>
            new PatronViewModel(Color.FromRgb(255, 215, 0), name);
        public static PatronViewModel Platinum(string name) =>
            new PatronViewModel(Color.FromRgb(170, 169, 202), name);
    }
}
