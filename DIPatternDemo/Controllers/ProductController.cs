using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
    public class ProductController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env; //Image Upload
        private readonly IProductServices service;
        private readonly ICategoryServices cat;

        public ProductController(IProductServices service, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ICategoryServices cat)
        {
            this.service = service; 
            this.env = env;
            this.cat = cat;
        }
        
        public ActionResult Index()
        {
            return View(service.GetAllProduct());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetProductById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories=cat.GetCategories();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod, IFormFile file)
        {
            try
            {
                //to upload image into image folder...
                using(var fs=new FileStream(env.WebRootPath+"\\image\\"+file.FileName,FileMode.Create,FileAccess.Write))
                    {
                    file.CopyTo(fs);
                    }

                //to store img url only in database
                prod.ImageUrl="~/image/"+file.FileName;

                var res=service.AddProduct(prod);
                if (res >= 1)
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
                ViewBag.Error = e.Message;
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = cat.GetCategories();
            var prod=service.GetProductById(id);
            TempData["oldUrl"]= prod.ImageUrl;
            TempData.Keep("oldUrl");
            return View(prod);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product  prod, IFormFile file)
        {
            try
            {
                string oldimgurl =TempData["oldUrl"].ToString();

                if (file != null)
                {
                    //to upload image into image folder...
                    using (var fs = new FileStream(env.WebRootPath + "\\image\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }

                    //to store img url only in database
                    prod.ImageUrl = "~/image/"+file.FileName;

                    //to delect old image 
                    string[] str = oldimgurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath+"\\image\\" + str1;
                    System.IO.File.Delete(path);
                }
                else
                {
                    prod.ImageUrl = oldimgurl;
                }

                int res = service.UpdateProduct(prod);
                if (res == 1)
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
                ViewBag.Error = e.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
