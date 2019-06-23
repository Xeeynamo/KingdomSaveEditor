using System;

namespace KHSave.SaveEditor.Common.Exceptions
{
    public class SaveNotSupportedException : Exception
    {
        public SaveNotSupportedException(string message) : base(message)
        {
        }

        public string Title => "Save not supported";
    }
}
