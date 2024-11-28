using DIPatternDemo.Models;
using DIPatternDemo.Repositories;

namespace DIPatternDemo.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepo repo;
        public StudentServices(IStudentRepo repo)
        {
            this.repo = repo;
        }

        public int AddStudent(Student student)
        {
           return repo.AddStudent(student);
        }

        public int DeleteStudent(int id)
        {
            return  repo.DeleteStudent(id);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return repo.GetAllStudent();
        }

        public Student GetStudentById(int id)
        {
            return GetStudentById(id);
        }

        public int UpdateStudent(Student student)
        {
            return repo.UpdateStudent(student);
        }
    }
}
