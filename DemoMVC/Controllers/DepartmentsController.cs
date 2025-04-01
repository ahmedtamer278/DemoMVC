﻿using Demo.BLL.DataTransferObject.Departments;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class DepartmentsController(IDepartmentService departmentService ,IWebHostEnvironment webHostEnvironment,ILogger<DepartmentsController> logger) : Controller
    {
        private readonly IDepartmentService _departmentService = departmentService;
        private readonly IWebHostEnvironment _env = webHostEnvironment;
        private readonly ILogger<DepartmentsController> _logger = logger;

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentService.GetAll();
            return View(department); // Send Data From Action To View
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(DepartmentRequest request)
        { 
          if(!ModelState.IsValid)  return View(request);

            try
            {
                var result = _departmentService.Add(request);
                if (result > 0) return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, "Can't Create Department");
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
            var department = _departmentService.GetById(id.Value);
            if (department is null) return NotFound();

            return View(department);
            
        }
        #endregion
        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetById(id.Value);
            if (department is null) return NotFound();

            return View(department.ToUpdateRequest());
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id,DepartmentUpdateRequest request)
        {
            if(id != request.Id) return BadRequest();
            if (!ModelState.IsValid) return View(request);

            try
            {
                var result = _departmentService.Update(request);
                if (result > 0) return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, "Can't Update Department");
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
            var department = _departmentService.GetById(id.Value);
            if (department is null) return NotFound();

            return View(department);
        }

        [HttpPost,ActionName("Delete") ]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            try
            {
                var result = _departmentService.Delete(id.Value);
                if (result) return RedirectToAction(nameof(Index));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsProduction())
                {

                    _logger.LogError(ex.Message);

                    ModelState.AddModelError(string.Empty, "Can't Delete Department Now");     
                }

                return RedirectToAction(nameof(Index));
            }
           
        }
        #endregion
    }
}
