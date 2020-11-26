using KHSave.SaveEditor.Common.Exceptions;
using KHSave.SaveEditor.Interfaces;
using System;
using System.Windows;

namespace KHSave.SaveEditor.Services
{
    public class AlertMessage : IAlertMessage
    {
        private readonly IWindowManager windowManager;

        public AlertMessage(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
        }

        public void Info(string message, string title) =>
            Invoke(message, title, MessageBoxButton.OK, MessageBoxImage.Information);

        public void Warning(string message, string title) =>
            Invoke(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);

        public void Error(string message, string title) =>
            Invoke(message, title, MessageBoxButton.OK, MessageBoxImage.Error);

        public void Error(Exception exception) => Error(exception.Message, "Error");

        public void Error(VisualException exception) => Error(exception.Message, exception.Title);

        public bool? InfoQuestion(string message, string title) =>
            Invoke(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

        public bool? WarningQuestion(string message, string title) =>
            Invoke(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

        public bool? ErrorQuestion(string message, string title) =>
            Invoke(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Error);

        private bool? Invoke(string message, string title, MessageBoxButton buttons, MessageBoxImage severity)
        {
            switch (MessageBox.Show(windowManager.CurrentWindow, message, title, buttons, severity))
            {
                case MessageBoxResult.None:
                    return null;
                case MessageBoxResult.OK:
                    return true;
                case MessageBoxResult.Cancel:
                    return null;
                case MessageBoxResult.Yes:
                    return true;
                case MessageBoxResult.No:
                    return false;
                default:
                    return null;
            }
        }
    }
}
