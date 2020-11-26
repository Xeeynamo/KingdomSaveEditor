using KHSave.SaveEditor.Common.Exceptions;
using System;

namespace KHSave.SaveEditor.Interfaces
{
    public interface IAlertMessage
    {
        void Info(string message, string title = null);
        void Warning(string message, string title = null);
        void Error(string message, string title = null);
        void Error(Exception exception);
        void Error(VisualException exception);
        bool? InfoQuestion(string message, string title = null);
        bool? WarningQuestion(string message, string title = null);
        bool? ErrorQuestion(string message, string title = null);
    }
}
