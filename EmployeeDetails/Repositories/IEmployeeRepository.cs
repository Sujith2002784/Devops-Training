using EmployeeDetails.Models;

namespace EmployeeDetails.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartmentNameAsync(string departmentName);
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(EmployeeDto employeeDto);
        Task<Employee> UpdateEmployeeAsync(int id, NewEmpDto updatedEmployeeDto);
        Task<EmployeeDto> DeleteEmployeeAsync(int id);
    }
}
