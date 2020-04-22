namespace KHSave.SaveEditor.Interfaces
{
    public interface IApplicationStartup
    {
        bool IsDebugging { get; }
        string StartupFileName { get; }
    }
}
