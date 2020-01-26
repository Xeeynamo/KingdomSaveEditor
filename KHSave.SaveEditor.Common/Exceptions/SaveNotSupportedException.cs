namespace KHSave.SaveEditor.Common.Exceptions
{
    public class SaveNotSupportedException : VisualException
    {
        public SaveNotSupportedException(string message) :
            base(message, "Save not supported")
        { }
    }
}
