using InterviewProject.Models;
using InterviewProject.Repostiory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewProject.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("~/api/verify-employment")]
        public IActionResult VerifyEmp(Employee emp)
        {
            if (emp != null)
            {
                var isEmpExist = _employeeRepository.IsEmployeeExist(emp);
                var getEmpfromDb = _employeeRepository.GetEmployee(emp.EmployeeID);
                if (isEmpExist && getEmpfromDb != null)
                {
                    if (getEmpfromDb.VerificationCode.ToLower() == emp.VerificationCode.ToLower())
                    {
                        return Ok(emp);
                    }
                    return new JsonResult("status", "notfound");
                }
            }
            return NotFound();
        }
    }


}

