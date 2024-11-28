using DIPatternDemo.Data;
using DIPatternDemo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DIPatternDemo.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext db;
        public StudentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddStudent(Student student)
        {
            int result = 0;
            db.Students?.Add(student);
            result=db.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            var res=db.Students?.Where(x=>x.Sid == id).SingleOrDefault();
            if(res != null)
            {
                db.Students?.Remove(res);
                result=db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return db.Students?.Where(x => x.Sid == id).SingleOrDefault();
        }

        public int UpdateStudent(Student student)
        {
            int result = 0;

            var res=db.Students?.Where(x=>x.Sid == student.Sid).SingleOrDefault();

            if(res!=null)
            {
                res.Sname = student.Sname;
                res.Department = student.Department;
                res.Percentage = student.Percentage;

                result = db.SaveChanges();
            }
            return result;

        }

       
    }
}
