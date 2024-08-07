using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class Employee
    {
        [Required]
        public string EmployeeID { get; set; } = string.Empty;

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string VerificationCode { get; set; } = string.Empty;
    }
}
