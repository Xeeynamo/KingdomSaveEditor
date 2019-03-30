using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools;

namespace KHSave.SaveEditor.Models
{
	public class GenericEntryModel<TName, TValue> : BaseNotifyPropertyChanged
	{
		public TName Name { get; set; }

		public TValue Value { get; set; }

		public override string ToString() => Name?.ToString() ?? Value?.ToString() ?? "<null>";
	}

	public class GenericEntryModel<TValue>
	{
		public string Name { get; set; }

		public TValue Value { get; set; }
	}
}
