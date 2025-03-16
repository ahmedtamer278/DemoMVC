using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class DepartmentController(IDepartmentService departmentService) : Controller
    {
        private readonly IDepartmentService _departmentService = departmentService;

        public IActionResult Index()
        {
            return View();
        }
    }
}
