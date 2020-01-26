using System;

namespace KHSave.SaveEditor.Common.Exceptions
{
    public class VisualException : Exception
    {
        public VisualException(string message, string title) :
            base(message)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
