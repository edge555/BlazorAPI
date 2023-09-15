using BlazorAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public StudentRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Task<List<Student>> GetStudentsAsync()
        {
            return _dbcontext.Students.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Student> PostStudentAsync(Student student)
        {
            var newStudent = _dbcontext.Students.Add(student);
            await _dbcontext.SaveChangesAsync();
            return newStudent.Entity;
        }
    }
}
