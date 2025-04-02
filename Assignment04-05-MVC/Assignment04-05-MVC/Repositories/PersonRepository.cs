using Assignment04_05_MVC.Models;
using System;

namespace Assignment04_05_MVC.Repositories;

public class PersonRepository : IPersonRepository
{
    private List<Person> ListPerson = new()
    {
        new Person { Id = 1, FirstName="Hung", LastName="Nguyen", DateOfBirth = new DateTime(2003, 1, 1), BirthPlace="Hai Duong", Gender = Gender.Male, PhoneNumber = "0946928815", IsGraduated = false },
        new Person { Id = 2, FirstName="Lan", LastName="Le", DateOfBirth = new DateTime(1995, 3, 14), BirthPlace="Hanoi", Gender = Gender.Female, PhoneNumber = "0908123456", IsGraduated = true },
        new Person { Id = 3, FirstName="Minh", LastName="Tran", DateOfBirth = new DateTime(2001, 6, 20), BirthPlace="Ho Chi Minh City", Gender = Gender.Male, PhoneNumber = "0912345678", IsGraduated = true },
        new Person { Id = 4, FirstName="Hoa", LastName="Nguyen", DateOfBirth = new DateTime(2002, 8, 25), BirthPlace="Bac Giang", Gender = Gender.Female, PhoneNumber = "0987654321", IsGraduated = false },
        new Person { Id = 5, FirstName="Duc", LastName="Nguyen", DateOfBirth = new DateTime(1998, 2, 10), BirthPlace="Quang Ninh", Gender = Gender.Male, PhoneNumber = "0911234567", IsGraduated = true },
        new Person { Id = 6, FirstName="Thanh", LastName="Pham", DateOfBirth = new DateTime(1999, 12, 5), BirthPlace="Can Tho", Gender = Gender.Male, PhoneNumber = "0976543210", IsGraduated = false },
        new Person { Id = 7, FirstName="Bich", LastName="Ngo", DateOfBirth = new DateTime(2000, 4, 1), BirthPlace="Hue", Gender = Gender.Female, PhoneNumber = "0919876543", IsGraduated = false },
        new Person { Id = 8, FirstName="Kien", LastName="Do", DateOfBirth = new DateTime(2001, 7, 13), BirthPlace="Da Nang", Gender = Gender.Male, PhoneNumber = "0945566778", IsGraduated = true },
        new Person { Id = 9, FirstName="Tuan", LastName="Vu", DateOfBirth = new DateTime(2002, 9, 9), BirthPlace="Hai Phong", Gender = Gender.Male, PhoneNumber = "0939876543", IsGraduated = true },
        new Person { Id = 10, FirstName="Mai", LastName="Tran", DateOfBirth = new DateTime(1996, 11, 20), BirthPlace="Quang Nam", Gender = Gender.Female, PhoneNumber = "0909876543", IsGraduated = true },
        new Person { Id = 11, FirstName="Ngoc", LastName="Pham", DateOfBirth = new DateTime(1997, 1, 15), BirthPlace="Binh Duong", Gender = Gender.Female, PhoneNumber = "0944556678", IsGraduated = true },
        new Person { Id = 12, FirstName="Cuong", LastName="Le", DateOfBirth = new DateTime(1998, 5, 18), BirthPlace="Ninh Binh", Gender = Gender.Male, PhoneNumber = "0901234567", IsGraduated = false },
        new Person { Id = 13, FirstName="Quyen", LastName="Nguyen", DateOfBirth = new DateTime(1996, 3, 3), BirthPlace="Thai Nguyen", Gender = Gender.Female, PhoneNumber = "0912345679", IsGraduated = true },
        new Person { Id = 14, FirstName="Thao", LastName="Nguyen", DateOfBirth = new DateTime(1999, 6, 22), BirthPlace="Vinh", Gender = Gender.Female, PhoneNumber = "0978765432", IsGraduated = true },
        new Person { Id = 15, FirstName="Toan", LastName="Mai", DateOfBirth = new DateTime(2000, 10, 10), BirthPlace="Nam Dinh", Gender = Gender.Male, PhoneNumber = "0965432109", IsGraduated = false },
        new Person { Id = 16, FirstName="Trang", LastName="Phan", DateOfBirth = new DateTime(2002, 1, 25), BirthPlace="Bac Ninh", Gender = Gender.Female, PhoneNumber = "0912837465", IsGraduated = false },
        new Person { Id = 17, FirstName="Son", LastName="Nguyen", DateOfBirth = new DateTime(2003, 3, 11), BirthPlace="Nha Trang", Gender = Gender.Male, PhoneNumber = "0949284721", IsGraduated = false },
        new Person { Id = 18, FirstName="Bich", LastName="Vu", DateOfBirth = new DateTime(1995, 7, 7), BirthPlace="Quang Tri", Gender = Gender.Female, PhoneNumber = "0987432156", IsGraduated = true },
        new Person { Id = 19, FirstName="Nhan", LastName="Le", DateOfBirth = new DateTime(2001, 4, 25), BirthPlace="HCM", Gender = Gender.Male, PhoneNumber = "0948765432", IsGraduated = true },
        new Person { Id = 20, FirstName="Thu", LastName="Pham", DateOfBirth = new DateTime(1997, 8, 30), BirthPlace="Kien Giang", Gender = Gender.Female, PhoneNumber = "0906754321", IsGraduated = true },
        new Person { Id = 21, FirstName="Lan", LastName="Mai", DateOfBirth = new DateTime(1994, 12, 2), BirthPlace="Lam Dong", Gender = Gender.Female, PhoneNumber = "0976543211", IsGraduated = true },
    };
    public void Add(Person person)
    {
        var newId = ListPerson.Max(x => x.Id) + 1;
        person.Id = newId;
		ListPerson.Insert(0,person);
    }

    public IQueryable<Person> GetAllQueryAble()
    {
        return ListPerson.AsQueryable();
    }

	public bool IsExist(int id)
	{
        return ListPerson.Any(x => x.Id == id);
	}

	public void Remove(Person person)
    {
        ListPerson.Remove(person);

    }

    public void Update(Person person)
    {
        var index = ListPerson.FindIndex(x => x.Id == person.Id);
        ListPerson[index] = person;
    }
}
