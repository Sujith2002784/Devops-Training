using EmployeeDetails.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeDetails.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync() { return await _context.Employees.Include(e => e.Department).Select(e => new EmployeeDto { Id = e.Id, EmpName = e.EmpName, EmpAddress = e.EmpAddress, DeptName = e.Department.DeptName, JoiningDate = e.JoiningDate, CreateDate = e.CreateDate, Salary = e.Salary, PhoneNumber = e.PhoneNumber, DepartmentId = e.DepartmentId, IsActive = e.IsActive }).ToListAsync(); }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartmentNameAsync(string departmentName)
        {
            var employees = await _context.Employees
                .Where(e => e.Department.DeptName == departmentName)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmpName = e.EmpName,
                    EmpAddress = e.EmpAddress,
                    DeptName = e.Department.DeptName,
                    JoiningDate = e.JoiningDate,
                    CreateDate = e.CreateDate,
                    Salary = e.Salary,
                    PhoneNumber = e.PhoneNumber,
                    DepartmentId = e.DepartmentId,
                    IsActive = e.IsActive
                })
                .ToListAsync();

            return employees;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmpName = e.EmpName,
                    EmpAddress = e.EmpAddress,
                    JoiningDate = e.JoiningDate,
                    CreateDate = e.CreateDate,
                    Salary = e.Salary,
                    PhoneNumber = e.PhoneNumber,
                    DeptName = e.Department.DeptName,
                    IsActive = e.IsActive
                })
                .FirstOrDefaultAsync();
            
        }

        public async Task<Employee> AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                EmpName = employeeDto.EmpName,
                EmpAddress = employeeDto.EmpAddress,
                JoiningDate = employeeDto.JoiningDate,
                CreateDate = DateTime.Now,
                Salary = employeeDto.Salary,
                PhoneNumber = employeeDto.PhoneNumber,
                DepartmentId = employeeDto.DepartmentId,
                IsActive = employeeDto.IsActive
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, NewEmpDto updatedEmployeeDto)
        {
            try
            {
                var existingEmployee = await _context.Employees.FindAsync(id);
                if (existingEmployee == null)
                {
                    return null;
                }

                existingEmployee.EmpName = updatedEmployeeDto.EmpName;
                existingEmployee.EmpAddress = updatedEmployeeDto.EmpAddress;
                existingEmployee.PhoneNumber = updatedEmployeeDto.PhoneNumber;
                existingEmployee.DepartmentId = updatedEmployeeDto.DepartmentId;
                existingEmployee.IsActive = updatedEmployeeDto.IsActive;

                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();
                return existingEmployee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }
            public async Task<EmployeeDto> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmpName = e.EmpName,
                    EmpAddress = e.EmpAddress,
                    JoiningDate = e.JoiningDate,
                    CreateDate = e.CreateDate,
                    Salary = e.Salary,
                    PhoneNumber = e.PhoneNumber,
                    DeptName = e.Department.DeptName,
                    IsActive = e.IsActive
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return null;
            }

            var entity = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
