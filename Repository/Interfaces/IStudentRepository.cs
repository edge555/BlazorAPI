namespace BlazorAPI.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> PostStudentAsync(Student student);
    }
}
