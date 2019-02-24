using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KHSave.Attributes;
using Xe.Tools.Models;

namespace KH02.SaveEditor.Models
{
	public class GenericEnumModel<TModel, T> : IEnumerable<TModel>
		where T : struct, IConvertible
		where TModel : EnumItemModel<T>
	{
		private readonly TModel[] items;

		public GenericEnumModel()
		{
			var type = typeof(T);
			if (type.IsEnum == false)
			{
				throw new InvalidOperationException($"{type} is not an enum.");
			}

			items = Enum.GetValues(type)
				.Cast<T>()
				.Select(e =>
				{
					var item = Activator.CreateInstance<TModel>() as EnumItemModel<T>;
					item.Value = e;
					item.Name = InfoAttribute.GetInfo(e);

					return (TModel)item;
				}).ToArray();
		}

		public IEnumerator<TModel> GetEnumerator()
		{
			return items.AsEnumerable().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public EnumItemModel<T> this[int i] => items[i];
	}

	public class GenericEnumModel<T> : GenericEnumModel<EnumItemModel<T>, T>
		where T : struct, IConvertible
	{
	}
}
