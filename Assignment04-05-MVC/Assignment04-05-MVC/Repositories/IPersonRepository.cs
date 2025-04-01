using Assignment04_05_MVC.Models;

namespace Assignment04_05_MVC.Repositories;

public interface IPersonRepository
{
    IQueryable<Person> GetAllQueryAble();
    void Remove(Person entity);
    void Add(Person entity);
    void Update(Person entity);
}
