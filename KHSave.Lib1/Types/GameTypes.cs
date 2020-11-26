using System;

namespace KHSave.Lib1.Types
{
    [Flags]
    public enum GameTypes
    {
        None,
        Jp = 1,
        EuUs = 2,
        Fm = 4,
        All = Jp | EuUs | Fm
    }
}
