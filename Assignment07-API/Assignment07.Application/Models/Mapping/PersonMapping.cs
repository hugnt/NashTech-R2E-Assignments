using Assignment07.Application.Models.Requests;
using Assignment07.Application.Models.Responses;
using Assignment07.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment07.Application.Models.Mapping
{
	public static class PersonMapping
	{
        public static Person ToEntity (this PersonRequest personRequest) => new Person()
		{
			FirstName = personRequest.FirstName,
			LastName = personRequest.LastName,
			Gender = personRequest.Gender,
			DateOfBirth = personRequest.DateOfBirth,
			BirthPlace = personRequest.BirthPlace
		};

		public static PersonResponse ToResponse(this Person person) => new PersonResponse()
		{
			Id = person.Id,
			FirstName = person.FirstName,
			LastName = person.LastName,
			Gender = person.Gender,
			DateOfBirth = person.DateOfBirth,
			BirthPlace = person.BirthPlace
		};
	}
}
