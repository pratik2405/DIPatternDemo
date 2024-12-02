using DIPatternDemo.Models;
using DIPatternDemo.Repositories;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace DIPatternDemo.Controllers
{
    public class RegitrationController : Controller
    {
        private readonly IRegistrationServices services;
        //private readonly IHttpContextAccessor HttpContextAccessor;

        public RegitrationController(IRegistrationServices services)
        {
            this.services = services;
            //httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Registration User)
        {
            try
            {
                var res = services.AddUser(User);

                if (res >= 1)
                {
                    return RedirectToAction("Login", "Regitration");
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View("Create");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Create");
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Registration User)
        {
            try
            {
                var res = services.GetUser(User);
               
                if (res != null)
                {
                    string Name = res.Name;
                    HttpContext.Session.SetString("Name", Name);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewBag.Error = "Check mail id or password !";
                    return View();
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Create");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
