using Assignment04_05_MVC.Common;
using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.Services;

public interface IPersonService
{
    public List<Person> GetByFilter(FilterModel filter);
	public ResultModel<Person> GetById(int id);
	public ResultModel<Person> Add(Person person);
	public ResultModel<Person> Update(int id, Person person);
	public ResultModel<bool> Delete(int id);
}
