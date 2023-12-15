using Models;

namespace BusinessLogicLayer
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
