using InterviewProject.Models;

namespace InterviewProject.Repostiory
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employee = new List<Employee>()
        {
            new Employee(){EmployeeID="AD101", CompanyName="ABC.Ltd", VerificationCode="ABC009"},
            new Employee(){EmployeeID="AD102", CompanyName="ABC.Ltd", VerificationCode="ABC009"},
            new Employee(){EmployeeID="BM101", CompanyName="BCD.Ltd", VerificationCode="ABC009"},
            new Employee(){EmployeeID="BM102", CompanyName="BCD.Ltd", VerificationCode="ABC009"},
            new Employee(){EmployeeID="XY101", CompanyName="XYZ.Ltd", VerificationCode="ABC009"}
        };

        public Employee? GetEmployee(string employeeID)
        {
            if (employeeID != null)
            {
                var employee = _employee.FirstOrDefault(x => x.EmployeeID == employeeID);
                return employee;
            }
            return null;
        }

        public bool IsEmployeeExist(Employee employee)
        {
            return _employee.Any(x => x.EmployeeID == employee.EmployeeID);
        }
    }
}
