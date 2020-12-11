using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KHSave.Services
{
    public static class TransferServiceLL
    {
        public static Dictionary<Type, Action<object, object, PropertyInfo>> DefaultMappings =
            new Dictionary<Type, Action<object, object, PropertyInfo>>()
            {
                [typeof(byte[])] = new Action<object, object, PropertyInfo>((dst, src, prop) => CopyArray<byte>(dst, src, prop)),
                [typeof(short[])] = new Action<object, object, PropertyInfo>((dst, src, prop) => CopyArray<short>(dst, src, prop)),
                [typeof(ushort[])] = new Action<object, object, PropertyInfo>((dst, src, prop) => CopyArray<ushort>(dst, src, prop)),
                [typeof(int[])] = new Action<object, object, PropertyInfo>((dst, src, prop) => CopyArray<int>(dst, src, prop)),
                [typeof(uint[])] = new Action<object, object, PropertyInfo>((dst, src, prop) => CopyArray<uint>(dst, src, prop)),
                [typeof(float[])] = new Action<object, object, PropertyInfo>((dst, src, prop) => CopyArray<float>(dst, src, prop)),
            };

        public static void CopySave<T>(object dst, object src, Dictionary<Type, Action<object, object, PropertyInfo>> mappings) where T : class =>
            CopySave(typeof(T), dst, src, mappings);

        public static void CopySave(Type type, object dst, object src, Dictionary<Type, Action<object, object, PropertyInfo>> mappings)
        {
            foreach (var property in type.GetProperties().Where(x => x.GetMethod != null))
            {
                if (mappings.TryGetValue(property.PropertyType, out var action))
                    action(dst, src, property);
                else if (property.PropertyType.IsPrimitive || property.PropertyType.IsEnum)
                {
                    if (property.SetMethod != null)
                        property?.SetValue(dst, property.GetValue(src));
                }
                else if (property.PropertyType.IsArray || property.PropertyType.IsAssignableFrom(typeof(IList)))
                {
                    var dstList = property.GetValue(dst) as IList;
                    var srcList = property.GetValue(src) as IList;
                    if (dstList != null && srcList != null)
                    {
                        var length = Math.Min(dstList.Count, srcList.Count);
                        var itemType = property.PropertyType.IsArray ?
                            property.PropertyType.GetElementType() :
                            property.PropertyType.GetGenericArguments().FirstOrDefault();
                        for (var i = 0; i < length; i++)
                        {
                            if (dstList[i] != null && srcList[i] != null)
                                CopySave(itemType, dstList[i], srcList[i], mappings);
                        }

                        if (property.SetMethod != null)
                            property.SetValue(dst, dstList);
                    }
                }
                else if (property.PropertyType.IsInterface || property.PropertyType.IsClass)
                {
                    CopySave(property.PropertyType, property.GetValue(dst), property.GetValue(src), mappings);
                }
            }
        }

        public static void CopyArray<T>(object dst, object src, PropertyInfo prop)
        {
            var srcValue = prop.GetValue(src) as T[];
            var dstValue = prop.GetValue(dst) as T[];
            if (dstValue != null)
                Array.Copy(srcValue, dstValue, Math.Min(srcValue.Length, dstValue.Length));
            else
                dstValue = srcValue;

            prop.SetValue(dst, dstValue);
        }
    }
}
