using BlazorAPI.Service;
using BlazorAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Controllers
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
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsAsync()
        {
            return Ok(await _studentService.GetStudentsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudentsAsync(Student student)
        {
            return Ok(await _studentService.PostStudentsAsync(student));
        }
    }
}
