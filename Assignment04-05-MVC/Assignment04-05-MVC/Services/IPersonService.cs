using Assignment04_05_MVC.Helper;
using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.Services;

public interface IPersonService
{
    public List<Person> GetByFilter(FilterModel filter);
}
