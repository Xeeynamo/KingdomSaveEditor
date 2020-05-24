using System;

namespace KHSave.Lib2.Types
{
    [Flags]
    public enum GameType
    {
        None,
        Jp = 1,
        EuUs = 2,
        Fm = 4,
        All = Jp | EuUs | Fm
    }
}
