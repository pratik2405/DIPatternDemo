using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices services;
        public StudentController(IStudentServices services)
        {
            this.services = services;
        }
        public ActionResult Index()
        {
            var res=services.GetAllStudent();
            return View(res);
        }

        
        public ActionResult Details(int id)
        {
            var res=services.GetStudentById(id);
            return View(res);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            try
            {
                var res = services.AddStudent(std);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went worng !");
                    return View();
                }
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            var res= services.GetStudentById(id);
            return View(res);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student std)
        {
            try
            {
                var res = services.UpdateStudent(std);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went worng !");
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            var res=services.GetStudentById(id);
            return View(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var res = services.DeleteStudent(id);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went worng !");
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
