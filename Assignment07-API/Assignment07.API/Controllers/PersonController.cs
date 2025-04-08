using Assignment07.Application.Models.Requests;
using Assignment07.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment07.API.Controllers
{
	[Route("api/person")]
	[ApiController]
	public class PersonController : ControllerBase
	{
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
			_personService = personService;

		}

		[HttpPost]
		public IActionResult Add([FromBody] PersonRequest newPerson)
		{
			return Ok(_personService.Add(newPerson));
		}

		[HttpPut("{id}")]
		public IActionResult Update(Guid id,[FromBody] PersonRequest updatedPerson)
		{
			return Ok(_personService.Update(id,updatedPerson));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			return Ok(_personService.Delete(id));
		}


		[HttpGet]
		public IActionResult Filter([FromQuery]PersonFilterRequest filterModel)
		{
			return Ok(_personService.Filter(filterModel));
		}
	}
}
