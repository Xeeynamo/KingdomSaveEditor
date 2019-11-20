using System.Windows;

namespace KHSave.SaveEditor.Interfaces
{
    public interface IWindowManager
    {
        bool IsRoot { get; }
        Window RootWindow { get; set; }
        Window CurrentWindow { get; }

        void Push<TWindow>() where TWindow : Window;
        void Push(Window window);

        void Pull();
    }
}
