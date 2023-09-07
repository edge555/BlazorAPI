using BlazorAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public StudentController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsAsync()
        {
            List<Student> students = await _dbcontext.Students.OrderBy(x => x.Id).ToListAsync();
            IEnumerable<Student> studentList = students;
            return Ok(studentList);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudentsAsync(Student request)
        {
            var newStudent = _dbcontext.Students.Add(request);
            await _dbcontext.SaveChangesAsync();
            return newStudent.Entity;
        }
    }
}
