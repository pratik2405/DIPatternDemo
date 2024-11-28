using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext db;
        public EmployeeRepo(ApplicationDbContext db)
        {
            this.db = db; 
        }
        public int AddEmployee(Employee employee)
        {
            int result = 0;
            db.Employees?.Add(employee);
            result= db.SaveChanges();
            return result;
        }

        public int DeleteEmployee(int id)
        {
            int result = 0;
            var emp=db.Employees?.Where(x=>x.Eid==id).FirstOrDefault();
            if(emp != null)
            {
                db.Employees?.Remove(emp);
                result=db.SaveChanges();

            }
            return result;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Employees?.Where(x => x.Eid == id).SingleOrDefault();
        }

        public int UpdateEmployee(Employee employee)
        {
            int result = 0;
            var emp = db.Employees?.Where(x => x.Eid ==employee.Eid).FirstOrDefault();
            if (emp != null)
            {
                emp.Ename= employee.Ename;
                emp.Email= employee.Email;
                emp.Esal= employee.Esal;

                result = db.SaveChanges();

            }
            return result;
        }
    }
}
