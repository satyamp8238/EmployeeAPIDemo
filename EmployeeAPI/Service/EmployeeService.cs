using EmployeeAPI.Model;

namespace EmployeeAPI.Service
{
    public class EmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        private int _nextId = 1;

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee? GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.EmployeeId = _nextId++;
            _employees.Add(employee);
            return employee;
        }

        public Employee? UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = GetEmployeeById(id);
            if (employee == null)
            {
                return null;
            }

            employee.FullName = updatedEmployee.FullName;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee == null)
            {
                return false;
            }
            _employees.Remove(employee);
            return true;
        }
    }
}
