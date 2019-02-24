using System;

namespace KH02.SaveEditor.Models
{
	public class ItemComboBoxModel<T>
		where T : struct, IConvertible
	{
		private readonly Func<T> _getter;
		private readonly Action<T> _setter;
		public GenericEnumModel<EnumIconTypeModel<T>, T> EquipmentType { get; }

		public T ItemId
		{
			get => _getter();
			set => _setter(value);
		}

		public ItemComboBoxModel(Func<T> getter, Action<T> setter)
		{
			_getter = getter;
			_setter = setter;

			EquipmentType = new GenericEnumModel<EnumIconTypeModel<T>, T>();
		}
	}
}
