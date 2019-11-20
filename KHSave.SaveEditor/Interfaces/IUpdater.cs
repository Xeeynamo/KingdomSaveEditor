using System.Threading.Tasks;

namespace KHSave.SaveEditor.Interfaces
{
    public interface IUpdater
    {
        bool IsAutomaticUpdatesEnabled { get; set; }

        Task<bool> AutomaticallyCheckLastVersionAsync();
        Task<bool> ForceCheckLastVersionAsync();
    }
}
