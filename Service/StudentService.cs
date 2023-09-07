using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Service
{
    public class StudentService
    {
        private readonly ApplicationDbContext _dbcontext;
        public StudentService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Student>> GetUsersAsync()
        {
            List<Student> students = await _dbcontext.Students.OrderBy(x => x.Id).ToListAsync();
            IEnumerable<Student> studentList = students;
            return studentList;
        }
    }
}
