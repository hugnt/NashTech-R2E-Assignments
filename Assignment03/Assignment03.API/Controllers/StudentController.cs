using Assignment03.API.Models;
using Assignment03.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment03.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }


        [HttpGet("{student_id}")]
        public IActionResult GetById(int student_id)
        {
            return Ok(_studentService.GetById(student_id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] StudentModel newStudent)
        {
            return Ok(_studentService.Add(newStudent));
        }

        [HttpPut("{student_id}")]
        public IActionResult Update(int student_id, [FromBody] StudentModel newStudent)
        {
            return Ok(_studentService.Update(student_id, newStudent));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_studentService.Delete(id));
        }
    }
}
