using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Common.Exceptions
{
	public class ObjectNotExistedException:Exception
	{
		public ObjectNotExistedException(string message):base(message) { }
	}
}
