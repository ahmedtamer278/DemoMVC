

using Demo.DAL.Models.ommon;

namespace DemoMVC.Controllers
{
    public class EmployeesController(IEmployeeService EmployeeService, IWebHostEnvironment webHostEnvironment, ILogger<EmployeesController> logger) : Controller
    {
        private readonly IEmployeeService _EmployeeService = EmployeeService;
        private readonly IWebHostEnvironment _env = webHostEnvironment;
        private readonly ILogger<EmployeesController> _logger = logger;

        [HttpGet]
        public IActionResult Index()
        {
            var Employee = _EmployeeService.GetAll();
            return View(Employee); // Send Data From Action To View
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // => Action Filter 
        public IActionResult Create(EmployeeRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            try
            {
                var result = _EmployeeService.Add(request);
                if (result > 0) return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, "Can't Create Employee");
                return View(request);
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                    _logger.LogError(ex.Message);
                }
            }
            return View(request);
        }

        #endregion
        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var Employee = _EmployeeService.GetById(id.Value);
            if (Employee is null) return NotFound();

            return View(Employee);

        }
        #endregion
        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var Employee = _EmployeeService.GetById(id.Value);
            if (Employee is null) return NotFound();

            var employeeRequest = new EmployeeUpdateRequest
            { 
                Id = Employee.Id,
                Address = Employee.Address,
                Age = Employee.Age,
                Email = Employee.Email,
                EmployeeType = Enum.Parse<EmployeeType>(Employee.EmployeeType) ,
                Gender = Enum.Parse<Gender>(Employee.Gender),
                HiringDate = Employee.HiringDate,
                IsActive = Employee.IsActive,
                Name = Employee.Name,
                PhoneNumber = Employee.PhoneNumber,
                Salary = Employee.Salary
            };
            return View(employeeRequest);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, EmployeeUpdateRequest request)
        {
            if (id != request.Id) return BadRequest();
            if (!ModelState.IsValid) return View(request);

            try
            {
                var result = _EmployeeService.Update(request);
                if (result > 0) return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, "Can't Update Employee");
                return View(request);
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                    _logger.LogError(ex.Message);
                }
            }
            return View(request);
        }
        #endregion
        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var Employee = _EmployeeService.GetById(id.Value);
            if (Employee is null) return NotFound();

            return View(Employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            try
            {
                var result = _EmployeeService.Delete(id.Value);
                if (result) return RedirectToAction(nameof(Index));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsProduction())
                {

                    _logger.LogError(ex.Message);

                    ModelState.AddModelError(string.Empty, "Can't Delete Employee Now");
                }

                return RedirectToAction(nameof(Index));
            }

        }
        #endregion
    }
}
