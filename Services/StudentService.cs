using BlazorAPI.Repository.Interfaces;
using BlazorAPI.Services.Exceptions;
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
        public async Task<Student?> UpdateStudentByIdAsync(int Id, Student student)
        {
            var studentData = await _studentRepository.GetStudentByIdAsync(Id);
            if(studentData == null)
            {
                throw new NotFoundException("Student not found.");
            }
            return await _studentRepository.UpdateStudentByIdAsync(Id, student);
        }
        public async Task<bool> DeleteStudentByIdAsync(int Id)
        {
            var studentData = await _studentRepository.GetStudentByIdAsync(Id);
            if (studentData == null)
            {
                throw new NotFoundException("Student not found.");
            }
            return await _studentRepository.DeleteStudentByIdAsync(Id);
        }
    }
}
