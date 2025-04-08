using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Common.Exceptions
{
	public class ValidationException: Exception
	{
        public ValidationException(IEnumerable<string> messages) : base(string.Join(",", messages))
		{
			
		}
	}
}
