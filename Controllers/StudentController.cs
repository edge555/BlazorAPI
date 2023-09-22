using BlazorAPI.Repository.Interfaces;
using BlazorAPI.Services;
using BlazorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentService studentService, IStudentRepository studentRepository)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsAsync()
        {
            return Ok(await _studentRepository.GetStudentsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudentAsync(Student student)
        {
            return Ok(await _studentRepository.PostStudentAsync(student));
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateStudentByIdAsync(int Id, [FromBody] Student student)
        {
            var updatedStudent = await _studentService.UpdateStudentByIdAsync(Id, student);
            return Ok(updatedStudent);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudentByIdAsync(int Id)
        {
            await _studentService.DeleteStudentByIdAsync(Id);
            return NoContent();

        }
    }
}
