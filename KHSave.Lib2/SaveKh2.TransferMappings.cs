using KHSave.Lib2.Types;
using KHSave.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KHSave.Lib2
{
    public partial class SaveKh2
    {
        public static Dictionary<Type, Action<object, object, PropertyInfo>> TransferMappings =
            new Dictionary<Type, Action<object, object, PropertyInfo>>()
            {
                [typeof(Difficulty)] = new Action<object, object, PropertyInfo>((dst, src, prop) =>
                {
                    var value = (Difficulty)prop.GetValue(src);
                    if (((ISaveKh2)dst).IsFinalMix == false && value == Difficulty.Critical)
                        value = Difficulty.Proud; // Downgrade difficulty for non-FinalMix
                    prop.SetValue(dst, value);
                }),
            }
            .Concat(TransferServiceLL.DefaultMappings)
            .GroupBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.First().Value);
    }
}
