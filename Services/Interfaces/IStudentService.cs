namespace BlazorAPI.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student> UpdateStudentByIdAsync(int Id, Student student);
        Task<Boolean> DeleteStudentByIdAsync(int Id);
    }
}
