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
				PhoneNumber = "555-0101",
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
				PhoneNumber = "555-0102",
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
				PhoneNumber = "555-0103",
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
				PhoneNumber = "555-0104",
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
				PhoneNumber = "555-0105",
				BirthPlace = "Miami",
				IsGraduated = false
			},
			new Person
			{
				Id = 6,
				FirstName = "Lisa",
				LastName = "Davis",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(1988, 12, 25),
				PhoneNumber = "555-0106",
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
				PhoneNumber = "555-0107",
				BirthPlace = "Boston",
				IsGraduated = false
			},
			new Person
			{
				Id = 8,
				FirstName = "Anna",
				LastName = "Taylor",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(1980, 2, 14),
				PhoneNumber = "555-0108",
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
				PhoneNumber = "555-0109",
				BirthPlace = "Denver",
				IsGraduated = false
			},
			new Person
			{
				Id = 10,
				FirstName = "Emily",
				LastName = "Martinez",
				Gender = Gender.Female,
				DateOfBirth = new DateTime(1987, 5, 27),
				PhoneNumber = "555-0110",
				BirthPlace = "Phoenix",
				IsGraduated = true
			}
		};
	}
}
