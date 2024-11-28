using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployee();

        Employee GetEmployeeById(int id);

        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);

        int DeleteEmployee(int id);
    }
}
