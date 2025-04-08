using Assignment07.Domain.Entities;
using Assignment07.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Persistence.Data;

public class DataProvider
{
    public static void SeedData(AppDbContext context)
    {
        context.Persons.AddRange(
            new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 5, 1), Gender = Gender.Male, BirthPlace = "New York", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1985, 8, 15), Gender = Gender.Female, BirthPlace = "Los Angeles", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Michael", LastName = "Johnson", DateOfBirth = new DateTime(1992, 3, 22), Gender = Gender.Male, BirthPlace = "Chicago", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Emily", LastName = "Davis", DateOfBirth = new DateTime(1988, 11, 30), Gender = Gender.Female, BirthPlace = "Miami", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "David", LastName = "Brown", DateOfBirth = new DateTime(1995, 1, 10), Gender = Gender.Male, BirthPlace = "Houston", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Sarah", LastName = "Williams", DateOfBirth = new DateTime(1993, 12, 5), Gender = Gender.Female, BirthPlace = "Dallas", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "James", LastName = "Miller", DateOfBirth = new DateTime(1990, 6, 25), Gender = Gender.Male, BirthPlace = "San Francisco", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Olivia", LastName = "Garcia", DateOfBirth = new DateTime(1994, 4, 18), Gender = Gender.Female, BirthPlace = "Seattle", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "William", LastName = "Martinez", DateOfBirth = new DateTime(1991, 7, 9), Gender = Gender.Male, BirthPlace = "Austin", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Isabella", LastName = "Rodriguez", DateOfBirth = new DateTime(1996, 2, 20), Gender = Gender.Female, BirthPlace = "Phoenix", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Liam", LastName = "Hernandez", DateOfBirth = new DateTime(1992, 10, 16), Gender = Gender.Male, BirthPlace = "Philadelphia", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Sophia", LastName = "Lopez", DateOfBirth = new DateTime(1994, 9, 13), Gender = Gender.Female, BirthPlace = "San Diego", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Ethan", LastName = "Gonzalez", DateOfBirth = new DateTime(1990, 4, 2), Gender = Gender.Male, BirthPlace = "Denver", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Mia", LastName = "Wilson", DateOfBirth = new DateTime(1993, 5, 30), Gender = Gender.Female, BirthPlace = "Salt Lake City", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Benjamin", LastName = "Anderson", DateOfBirth = new DateTime(1989, 12, 19), Gender = Gender.Male, BirthPlace = "Portland", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Charlotte", LastName = "Thomas", DateOfBirth = new DateTime(1996, 6, 27), Gender = Gender.Female, BirthPlace = "New Orleans", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Daniel", LastName = "Jackson", DateOfBirth = new DateTime(1987, 11, 22), Gender = Gender.Male, BirthPlace = "Cleveland", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Amelia", LastName = "White", DateOfBirth = new DateTime(1994, 10, 11), Gender = Gender.Female, BirthPlace = "Minneapolis", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Jacob", LastName = "Lee", DateOfBirth = new DateTime(1991, 8, 28), Gender = Gender.Male, BirthPlace = "Kansas City", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Person { FirstName = "Chloe", LastName = "Young", DateOfBirth = new DateTime(1992, 3, 17), Gender = Gender.Female, BirthPlace = "San Antonio", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        );

        context.SaveChanges(); // Save changes to the in-memory database
    }
}
