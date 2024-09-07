using Assignment.Data.Entities;
using Assignment.Repository.Interfaces;
using Assignment.Service.Interfaces.Department;
using Assignment.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Assignment03.MVC.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;


        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var departments= _departmentService.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult Create(DepartmentDto departmentDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(departmentDto);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Department Error", "Validation Error");
                return View(departmentDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Department Error", ex.Message);
                return View(departmentDto);
            }
        }

        public IActionResult Details(int? id,string viewName="Details") {

            var department = _departmentService.GetById(id);
            if (department is null)
                return NotFound();
            return View(viewName,department);

        }
        [HttpGet]
        public IActionResult Update(int? id)
        {

            return Details(id,"Update");
        }
        [HttpPost]
        public IActionResult Update(int? id,DepartmentDto departmentDto)
        {
            if (departmentDto.Id!=id.Value)
                return NotFound();
            _departmentService.Update(departmentDto);
            return RedirectToAction(nameof(Index));


        }
       
        public IActionResult Delete(int id)
        {

            var department = _departmentService.GetById(id);
            if (department is null)
                return NotFound();
            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        

        }


    }
}
