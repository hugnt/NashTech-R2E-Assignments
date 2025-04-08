using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Common.Exceptions
{
	public class ValidationException: Exception
	{
        public IEnumerable<string> Messages { get; private set; }
        public ValidationException(IEnumerable<string> messages) : base()
		{
			Messages = messages;
		}
	}
}
