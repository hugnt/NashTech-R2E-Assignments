using Assignment04_05_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_05_MVC.Tests.TestData;

public class RepositoryData
{
	public static List<Person> ListPersonsTest()
	{
		return new List<Person>
		{
			new Person
			{
				Id = 1,
				FirstName = "John",
				LastName = "Smith",
				Gender = Gender.Male,
				DateOfBirth = new DateTime(1985, 6, 15),
				PhoneNumber = "0123456789",
				BirthPlace = "New York",
				IsGraduated = true
			},
			new Person
			{
				Id = 2,
				FirstName = "Emma",
				LastName = "Johnson",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(1990, 3, 22),
				PhoneNumber = "0987654321",
				BirthPlace = "Los Angeles",
				IsGraduated = false
			},
			new Person
			{
				Id = 3,
				FirstName = "Michael",
				LastName = "Chen",
				Gender = Gender.Male,
				DateOfBirth = new DateTime(1978, 11, 30),
				PhoneNumber = "0765432109",
				BirthPlace = "Chicago",
				IsGraduated = true
			},
			new Person
			{
				Id = 4,
				FirstName = "Sarah",
				LastName = "Williams",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(1995, 7, 10),
				PhoneNumber = "0891234567",
				BirthPlace = "Houston",
				IsGraduated = true
			},
			new Person
			{
				Id = 5,
				FirstName = "David",
				LastName = "Brown",
				Gender = Gender.Male,
				DateOfBirth = new DateTime(1982, 9, 5),
				PhoneNumber = "0678901234",
				BirthPlace = "Miami",
				IsGraduated = false
			},
			new Person
			{
				Id = 6,
				FirstName = "Lisa",
				LastName = "Davis",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(2002, 12, 25),
				PhoneNumber = "0543210987",
				BirthPlace = "Seattle",
				IsGraduated = true
			},
			new Person
			{
				Id = 7,
				FirstName = "James",
				LastName = "Wilson",
				Gender = Gender.Male,
				DateOfBirth = new DateTime(1992, 4, 18),
				PhoneNumber = "0912345678",
				BirthPlace = "Boston",
				IsGraduated = false
			},
			new Person
			{
				Id = 8,
				FirstName = "Anna",
				LastName = "Taylor",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(2003, 2, 14),
				PhoneNumber = "0789012345",
				BirthPlace = "San Francisco",
				IsGraduated = true
			},
			new Person
			{
				Id = 9,
				FirstName = "Robert",
				LastName = "Lee",
				Gender = Gender.Male,
				DateOfBirth = new DateTime(1998, 8, 3),
				PhoneNumber = "0654321098",
				BirthPlace = "Denver",
				IsGraduated = false
			},
			new Person
			{
				Id = 10,
				FirstName = "Emily",
				LastName = "Martinez",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(2003, 5, 27),
				PhoneNumber = "0876543210",
				BirthPlace = "Phoenix",
				IsGraduated = true
			}
		};
	}
}
