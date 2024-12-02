using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices services;
        public CategoryController(ICategoryServices services)
        {
            this.services = services;   
        }

        public ActionResult Index()
        {
            var res = services.GetCategories(); 
            return View(res);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var res = services.GetCategoryById(id);
            return View(res);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            try
            {
                
                var res = services.AddCategory(cat);

                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went Worng !");
                    return View();
                }
            }
            catch ( Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var res= services.GetCategoryById(id);
            return View(res);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            try
            {
               
                var res = services.UpdateCategory(cat);

                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went Worng !");
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var res=services.GetCategoryById(id);
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                
                var res = services.DeleteCategory(id);

                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went Worng !");
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
