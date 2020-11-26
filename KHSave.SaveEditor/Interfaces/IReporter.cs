using System;

namespace KHSave.SaveEditor.Interfaces
{
    public interface IReporter
    {
        void SendGameName(string name);
        void SendCrashReport(Exception ex);
    }
}
