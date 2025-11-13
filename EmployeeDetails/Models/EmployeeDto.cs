namespace EmployeeDetails.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string DeptName { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

    }
}
