using KHSave.Lib2.Models;
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
                [typeof(IDriveForm[])] = new Action<object, object, PropertyInfo>((dst, src, prop) =>
                {
                    var isDstFinalMix = ((ISaveKh2)dst).IsFinalMix;
                    var isSrcFinalMix = ((ISaveKh2)src).IsFinalMix;
                    if (isDstFinalMix == isSrcFinalMix)
                        CopySame(((ISaveKh2)dst).DriveForms, ((ISaveKh2)src).DriveForms);
                    else if (isDstFinalMix)
                        CopyFromVanilla(((ISaveKh2)dst).DriveForms, ((ISaveKh2)src).DriveForms);
                    else if (isSrcFinalMix)
                        CopyFromFinalMix(((ISaveKh2)dst).DriveForms, ((ISaveKh2)src).DriveForms);
                }),
            }
            .Concat(TransferServiceLL.DefaultMappings)
            .GroupBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.First().Value);

        private static void CopySame(IDriveForm[] dst, IDriveForm[] src)
        {
            var length = Math.Min(dst.Length, src.Length);
            for (var i = 0; i < length; i++)
                TransferServiceLL.CopySave<IDriveForm>(dst[i], src[i], TransferMappings);
        }

        private static void CopyFromVanilla(IDriveForm[] dst, IDriveForm[] src)
        {
            var limitDriveForm = new DriveFormFinalMix(); // creates a default Limit
            limitDriveForm.Level = 1;
            limitDriveForm.Abilities = new ushort[0x18];
            limitDriveForm.Abilities[0] = 0x8234;
            limitDriveForm.Abilities[1] = 0x8239;
            limitDriveForm.Abilities[2] = 0x823A;
            limitDriveForm.Abilities[3] = 0x823B;
            limitDriveForm.Abilities[4] = 0x823C;
            limitDriveForm.Abilities[5] = 0x823D;
            limitDriveForm.Abilities[6] = 0x823E;
            limitDriveForm.Abilities[7] = 0x823F;
            limitDriveForm.Abilities[8] = 0x824B;
            limitDriveForm.Abilities[9] = 0x824C;
            limitDriveForm.Abilities[10] = 0x824D;
            limitDriveForm.Abilities[11] = 0x8052;
            limitDriveForm.Abilities[12] = 0x8106;
            limitDriveForm.Abilities[13] = 0x8108;
            limitDriveForm.Abilities[14] = 0x810D;
            limitDriveForm.Abilities[15] = 0x819C;
            limitDriveForm.Abilities[16] = 0x8195;
            limitDriveForm.Abilities[17] = 0x8197;
            limitDriveForm.Abilities[18] = 0x819D;
            dst[2] = limitDriveForm;

            TransferServiceLL.CopySave<IDriveForm>(dst[0], src[0], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[1], src[1], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[3], src[2], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[4], src[3], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[5], src[4], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[6], src[5], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[7], src[6], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[8], src[7], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[9], src[8], TransferMappings);
        }

        private static void CopyFromFinalMix(IDriveForm[] dst, IDriveForm[] src)
        {
            TransferServiceLL.CopySave<IDriveForm>(dst[0], src[0], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[1], src[1], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[2], src[3], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[3], src[4], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[4], src[5], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[5], src[6], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[6], src[7], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[7], src[8], TransferMappings);
            TransferServiceLL.CopySave<IDriveForm>(dst[8], src[9], TransferMappings);
        }
    }
}
