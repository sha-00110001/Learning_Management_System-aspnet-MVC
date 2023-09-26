using Microsoft.AspNetCore.Mvc;
using Task2MVC.Models;

namespace Task2MVC.Controllers
{
    public class CourseController : Controller
    {
        UniversityContext Context = new UniversityContext();
        public IActionResult ShowAll()
        {
            List <Course> courses = Context.Courses.ToList();
            return View(courses);
        }
        public IActionResult NewCrs()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveCrs(Course c)
        {
            if (ModelState.IsValid)
            {
                

                Context.Courses.Add(c);

                Context.SaveChanges();
                return RedirectToAction("ShowAll", c);
            }
            else
                return View("NewCrs", c);


        }

        public IActionResult EditCrs(int id)
        {

            Course c = Context.Courses.Find(id);

            //List<Department> depts = Context.Departments.ToList();
            //ViewData["depts"] = depts;


            return View(c);
        }
        [HttpPost]
        public IActionResult SaveAfterEdit(Course Newc, int Id)
        {

            Course Oldc = Context.Courses.Find(Id);
            if (ModelState.IsValid)
            {
                Oldc.name = Newc.name;
                Oldc.degree = Newc.degree;
                Oldc.mindgree = Newc.mindgree;
               
                Context.SaveChanges();
                return RedirectToAction("ShowAll");

            }
            return View("Edit", Newc);
        }

        
        public IActionResult DeleteCrs(int id)
        {
            return View(Context.Courses.Find(id));
        }


        public IActionResult Deletecrs2(int id)
        {
            Course c = Context.Courses.Find(id);
            Context.Remove(c);
            Context.SaveChanges();
            return RedirectToAction("ShowAll");
        }

    }
}
