using DIPatternDemo.Models;
using DIPatternDemo.Repositories;

namespace DIPatternDemo.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo repo;
        public EmployeeServices(IEmployeeRepo repo) 
        {
            this.repo = repo;
        }
        public int AddEmployee(Employee employee)
        {
            return repo.AddEmployee(employee);
        }

        public int DeleteEmployee(int id)
        {
            return repo.DeleteEmployee(id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return repo.GetAllEmployee();
        }

        public Employee GetEmployeeById(int id)
        {
            return repo.GetEmployeeById(id);
        }

        public int UpdateEmployee(Employee employee)
        {
            return repo.UpdateEmployee(employee);
        }
    }
}
