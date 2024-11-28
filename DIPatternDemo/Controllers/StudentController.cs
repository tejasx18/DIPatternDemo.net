using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var model = service.GetStudents();
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var model = service.GetStudentById(id);
            return View(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            try
            {
                int response = service.AddStudent(std);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMssg = "Student was not added";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMssg = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = service.GetStudentById(id);
            return View(model);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student std)
        {
            try
            {
                int response = service.UpdateStudent(std);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMssg = "Student was not Updated";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMssg = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = service.GetStudentById(id);
            return View(model);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, Student std)
        {
            try
            {
                int response = service.DeleteStudent(id);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMssg = "Student was not Deleted";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMssg = ex.Message;
                return View();
            }
        }
    }
}
