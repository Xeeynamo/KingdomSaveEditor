using System;
using System.Collections.Generic;
using System.Windows;
using KHSave.SaveEditor.Interfaces;
using Unity;

namespace KHSave.SaveEditor.Services
{
    public class WindowManager : IWindowManager
    {
        private Stack<Window> _windowStack;
        private Window rootWindow;
        private readonly IUnityContainer _container;

        public bool IsRoot => _windowStack.Count == 1;

        public Window RootWindow
        {
            get => rootWindow;
            set
            {
                _windowStack = new Stack<Window>();
                _windowStack.Push(value);
            }
        }

        public Window CurrentWindow => _windowStack.Peek();


        public WindowManager(IUnityContainer container)
        {
            _container = container;
        }

        public bool? Push<TWindow>(Action<TWindow> onSetup, Func<TWindow, bool> onSuccess) where TWindow : Window
        {
            var window = _container.Resolve<TWindow>();
            onSetup?.Invoke(window);
            
            var result = Push(window);
            return result == true ? onSuccess?.Invoke(window) ?? true : result;
        }

        public bool? Push(Window window)
        {
            _windowStack.Push(window);
            return window.ShowDialog();
        }

        public void Pull()
        {
            if (IsRoot)
                throw new Exception("Unable to pull root Window");

            _windowStack.Pop().Close();
        }
    }
}
