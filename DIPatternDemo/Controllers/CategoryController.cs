using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(service.GetCategories());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetCategoryById(id));
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
                int result = service.AddCategory(cat);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMssg = "Category not added";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMssg = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(service.GetCategoryById(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            try
            {
                int result = service.UpdateCategory(cat);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMssg = "Category was not updated";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMssg =ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.GetCategoryById(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = service.DeleteCategory(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMssg = "Category not deleted";
                    return View();
                }
            }
            catch(Exception ex) 
            {
                ViewBag.ErrorMssg = ex.Message;
                return View();
            }
        }
    }
}
