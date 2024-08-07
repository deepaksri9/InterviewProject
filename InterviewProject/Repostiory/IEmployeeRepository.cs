using InterviewProject.Models;

namespace InterviewProject.Repostiory
{
    public interface IEmployeeRepository
    {
        Employee? GetEmployee(string employeeID);
        bool IsEmployeeExist(Employee employee);
    }
}