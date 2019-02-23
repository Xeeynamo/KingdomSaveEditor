using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KHSave.Attributes;
using Xe.Tools.Models;

namespace KH02.SaveEditor.Models
{
	public class GenericEnumModel<T> : IEnumerable<EnumItemModel<T>>
		where T : struct, IConvertible
	{
		private readonly IEnumerable<EnumItemModel<T>> items;

		public GenericEnumModel()
		{
			var type = typeof(T);
			if (type.IsEnum == false)
			{
				throw new InvalidOperationException($"{type} is not an enum.");
			}

			items = Enum.GetValues(type)
				.Cast<T>()
				.Select(e => new EnumItemModel<T>()
				{
					Value = e,
					Name = InfoAttribute.GetInfo(e)
				});
		}

		public IEnumerator<EnumItemModel<T>> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}
	}
}
