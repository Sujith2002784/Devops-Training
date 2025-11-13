namespace EmployeeDetails.Models
{
    public class NewEmpDto
    {
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int DepartmentId { get; set; }

        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
