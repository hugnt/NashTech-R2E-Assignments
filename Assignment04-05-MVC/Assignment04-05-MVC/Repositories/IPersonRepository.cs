using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.Repositories;

public interface IPersonRepository
{
    IQueryable<Person> GetAllQueryAble();
    void Remove(Person person);
    void Add(Person person);
    void Update(Person person);
    bool IsExist(int id);
}
