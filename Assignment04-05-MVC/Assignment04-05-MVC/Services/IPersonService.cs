using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.Services;

public interface IPersonService
{
    public List<Person> GetByFilter(FilterModel filter);
	public Result<Person> GetById(int id);
	public Result Add(Person person);
	public Result Update(int id, Person person);
	public Result Delete(int id);
}
