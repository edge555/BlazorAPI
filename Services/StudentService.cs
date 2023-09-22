using BlazorAPI.Repository.Interfaces;
using BlazorAPI.Services.Interfaces;

namespace BlazorAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> UpdateStudentByIdAsync(int Id, Student student)
        {
            // id not found
            var updatedStudent = await _studentRepository.UpdateStudentByIdAsync(Id, student);
            return updatedStudent;
        }
        public async Task<bool> DeleteStudentByIdAsync(int Id)
        {
            // id not found
            return await _studentRepository.DeleteStudentByIdAsync(Id);
        }
    }
}
