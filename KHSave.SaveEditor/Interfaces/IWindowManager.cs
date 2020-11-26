using System;
using System.Windows;

namespace KHSave.SaveEditor.Interfaces
{
    public interface IWindowManager
    {
        bool IsRoot { get; }
        Window RootWindow { get; set; }
        Window CurrentWindow { get; }

        bool? Push<TWindow>(Action<TWindow> onSetup = null, Func<TWindow, bool> onSuccess = null) where TWindow : Window;
        bool? Push(Window window);

        void Pull();
    }
}
