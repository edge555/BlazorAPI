using Azure.Core;
using BlazorAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Service
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbcontext;
        public StudentService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Task<List<Student>> GetStudentsAsync()
        {
            return _dbcontext.Students.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Student> PostStudentsAsync(Student student)
        {
            var newStudent = _dbcontext.Students.Add(student);
            await _dbcontext.SaveChangesAsync();
            return newStudent.Entity;
        }
    }
}
