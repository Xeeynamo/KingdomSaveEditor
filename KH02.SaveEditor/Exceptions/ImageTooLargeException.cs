using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH02.SaveEditor.Exceptions
{
	public class ImageTooLargeException : Exception
	{
		public ImageTooLargeException(int sizeLimit) :
			base($"The image is too large and it cannot exceed {sizeLimit} bytes.")
		{
			
		}
	}
}
