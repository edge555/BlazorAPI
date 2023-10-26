using System.Dynamic;

namespace BlazorAPI.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<dynamic>> GetStudentsAsync(string query);
		Task<Student?> GetStudentByIdAsync(int Id);
        Task<Student> PostStudentAsync(Student student);
        Task<Student> UpdateStudentByIdAsync(int Id, Student student);
        Task<Boolean> DeleteStudentByIdAsync(int Id);
    }
}
