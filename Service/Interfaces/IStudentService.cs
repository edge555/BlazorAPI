namespace BlazorAPI.Service.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> PostStudentsAsync(Student student);
    }
}
