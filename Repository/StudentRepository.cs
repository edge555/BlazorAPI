using BlazorAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public Task<List<Student>> GetStudentsAsync()
        {
            return _dbContext.Students.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int Id)
        {
            return await _dbContext.Students.FindAsync(Id);
        }

        public async Task<Student> PostStudentAsync(Student student)
        {
            var newStudent = _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return newStudent.Entity;
        }

        public async Task<Student> UpdateStudentByIdAsync(int Id, Student student)
        {
            var studentData = await _dbContext.Students.FindAsync(Id);
            studentData.Name = student.Name;
            studentData.Roll = student.Roll;
            studentData.Class = student.Class;
            await _dbContext.SaveChangesAsync();
            return studentData;
        }

        public async Task<Boolean> DeleteStudentByIdAsync(int Id)
        {
            var student = await _dbContext.Students.FindAsync(Id);
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}