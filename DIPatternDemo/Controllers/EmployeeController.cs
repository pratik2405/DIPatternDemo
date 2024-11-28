using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices service; 
        public EmployeeController(IEmployeeServices service)
        {
            this.service = service;
        }
        
        public ActionResult Index()
        {
            var res=service.GetAllEmployee();
            return View(res);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee=service.GetEmployeeById(id);
            return View(employee);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                var result = service.AddEmployee(emp);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            var res= service.GetEmployeeById(id);
            return View(res);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                var result=service.UpdateEmployee(emp);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View();
                }
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            var delemp=service.GetEmployeeById(id);
            return View(delemp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var result = service.DeleteEmployee(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(); 
            }
        }
    }
}
