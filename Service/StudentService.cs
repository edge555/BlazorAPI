using BlazorAPI.Repository.Interfaces;
using BlazorAPI.Service.Interfaces;

namespace BlazorAPI.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;
        public StudentService(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }
        public Task<List<Student>> GetStudentsAsync()
        {
            return _StudentRepository.GetStudentsAsync();
        }

        public async Task<Student> PostStudentsAsync(Student student)
        {
            return await _StudentRepository.PostStudentAsync(student);
        }
    }
}
