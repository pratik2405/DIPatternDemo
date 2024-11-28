using DIPatternDemo.Models;

namespace DIPatternDemo.Services
{
    public interface IStudentServices
    {
        public IEnumerable<Student> GetAllStudent();

        public Student GetStudentById(int id);

        public int UpdateStudent(Student student);

        public int DeleteStudent(int id);

        public int AddStudent(Student student);
    }
}
