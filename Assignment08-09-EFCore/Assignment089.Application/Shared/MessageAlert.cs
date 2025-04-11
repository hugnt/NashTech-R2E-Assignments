using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Shared;

public static class MessageAlert
{
	public static string CreatedSuccessfully(string objName = "") => $"Added {objName} Successfully!";
	public static string UpdatedSuccessfully(string objName = "") => $"Updated {objName} Successfully!";
	public static string UpdatedSuccessfully(Guid id, string objName = "") => $"Updated {objName} with id = {id} Successfully!";
	public static string DeletedSuccessfully(Guid id, string objName = "") => $"Deleted {objName} with id = {id} Successfully!";
	public static string DeletedSuccessfully(string objName = "") => $"Deleted {objName} with Successfully!";


	public static string ObjectNotFound(Guid id, string objName = "") => $"{objName} with id = {id} is not existed!";
	public static string ObjectNotFound(Guid id, Guid id2, string objName1 = "", string objName2 = "") => $"{objName1} (id = {id}) with {objName2} (id={id2}) is not existed!";

	public static string ObjectExisted(Guid id, string objName1 = "") => $"{objName1} (id = {id}) is already existed!";
	public static string ObjectExisted(Guid id, Guid id2, string objName1 = "", string objName2 = "") => $"{objName1} (id = {id}) with {objName2} (id={id2}) is already existed!";

	public static string ServerError() => $"Somethings was wrong, please try again!";

}