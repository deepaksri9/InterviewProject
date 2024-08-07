using Microsoft.AspNetCore.Mvc;
using WebUI.Data;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class EmpVerificationController : Controller
    {
        private readonly IWebApiExecutor _apiExecutor;

        public EmpVerificationController(IWebApiExecutor apiExecutor)
        {
            _apiExecutor = apiExecutor;
        }

        public IActionResult EmpDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmpDetails(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _apiExecutor.InvokePost("verify-employment", employee);

                    if (response != null)
                    {
                        ViewBag.Status = "Success";
                        return View(response);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Status = "Failed";
                    return View();
                }
            }
            return View();
        }
    }
}
