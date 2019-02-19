using System;
using System.Collections.Generic;
using System.Text;

namespace KHSave.Extensions
{
	public static class BitExtensions
	{
		public static bool GetFlag(this int value, int bit)
		{
			return (value & (1 << bit)) != 0;
		}

		public static bool SetFlag(this int value, int bit, bool set)
		{
			if (set)
			{
				value |= 1 << bit;
			}
			else
			{
				value &= ~(1 << bit);
			}

			return value.GetFlag(bit);
		}
	}
}
