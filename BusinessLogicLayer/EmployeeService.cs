using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }
        public void AddEmployee(Employee employee)
        {
            _repository.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            _repository.Delete(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return _repository.Get(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}
