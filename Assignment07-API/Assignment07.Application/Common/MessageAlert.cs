using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Common
{
	public static class MessageAlert
	{
		public static string CreatedSuccessfully(string objName = "") => $"Added {objName} Successfully!";
		public static string UpdatedSuccessfully(Guid id,string objName = "") => $"Updated {objName} with id = {id} Successfully!";
		public static string DeletedSuccessfully(Guid id, string objName = "") => $"Deleted {objName} with id = {id} Successfully!";


		public static string ObjectNotFound(Guid id, string objName = "") => $"{objName} with id = {id} is not existed!";
	}
}
