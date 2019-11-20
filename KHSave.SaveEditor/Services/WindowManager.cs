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

        public void Push<TWindow>() where TWindow : Window =>
            Push(_container.Resolve<TWindow>());

        public void Push(Window window)
        {
            _windowStack.Push(window);
            window.ShowDialog();
        }

        public void Pull()
        {
            if (IsRoot)
                throw new Exception("Unable to pull root Window");

            _windowStack.Pop().Close();
        }
    }
}
