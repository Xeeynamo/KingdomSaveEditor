using KHSave.Lib2;
using KHSave.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace KHSave.SaveEditor.Services
{
    public static class TransferService
    {
        public enum Result
        {
            Success,
            GameNotSupported,
            SourceNotCompatible,
            InternalError,
        }

        public static Result Transfer(object dstSave, Stream srcSaveStream)
        {
            Result result;
            if (dstSave is ISaveKh2 && (result = Transfer(dstSave, srcSaveStream, SaveKh2.IsValid, SaveKh2.Read, SaveKh2.TransferMappings)) != Result.GameNotSupported)
                return result;

            return Result.GameNotSupported;
        }

        public static Result Transfer<T>(
            object save, Stream srcSaveStream, Func<Stream, bool> isValid, Func<Stream, T> read,
            Dictionary<Type, Action<object, object, PropertyInfo>> mappings)
            where T : class
        {
            if (!(save is T))
                return Result.GameNotSupported;

            if (!isValid(srcSaveStream.SetPosition(0)))
                return Result.SourceNotCompatible;

            var srcSave = read(srcSaveStream.SetPosition(0));
            if (!(srcSave is T))
                return Result.InternalError;

            TransferServiceLL.CopySave<T>(save, srcSave, mappings);
            return Result.Success;
        }
    }
}
