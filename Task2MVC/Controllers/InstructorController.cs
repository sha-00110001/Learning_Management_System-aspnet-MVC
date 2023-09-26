using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2MVC.Models;
using Task2MVC.ViewModels;

namespace Task2MVC.Controllers
{
    public class InstructorController : Controller
    {

        UniversityContext Context = new UniversityContext();
        public IActionResult ShowAll()
        {

            List<Instructor> instructors = Context.Instructors.ToList();
            return View(instructors);
        }
        public IActionResult Details(int id)
        {


            Instructor instr = Context.Instructors.FirstOrDefault(s => s.Id == id);

            return View(instr);
        }

        public IActionResult ShowAllWithVModel()
        {
            InstructorJoinDepartmentViewModel vm = new InstructorJoinDepartmentViewModel();
            List<Instructor> i = Context.Instructors.ToList();
            List<Department> d = Context.Departments.ToList();
            List<Course> c = Context.Courses.ToList();

           
            vm.Dept = d;
            vm.Instru = i;
            vm.Crs = c; 

            return View(vm);
        }

        public IActionResult New()
        {
            List<Department> depts = Context.Departments.ToList();
            ViewData["depts"] = depts;

            List<Course> crs = Context.Courses.ToList();
            ViewData["crs"] = crs;
            return View();
        }

        [HttpPost]
        public IActionResult Save(Instructor i)
        {
            List<Department> depts = Context.Departments.ToList();
            ViewData["depts"] = depts;

            List<Course> crs = Context.Courses.ToList();
            ViewData["crs"] = crs;

            if (ModelState.IsValid==true)
            {
                Context.Instructors.Add(i);

                Context.SaveChanges();
                return RedirectToAction("ShowAllWithVModel", i);
            }
            else 
                return View("New",i);

           
        }
        public IActionResult Edit (int id)
        {

            Instructor instr = Context.Instructors.Find(id);

            List<Department> depts = Context.Departments.ToList();
            ViewData["depts"] = depts;

            List<Course> crs = Context.Courses.ToList();
            ViewData["crs"] = crs;

            return View(instr);
        }
        [HttpPost]
        public IActionResult SaveAfterEdit(Instructor NewI, int Id)
        {
            Instructor OldI = Context.Instructors.Find(Id);

            List<Department> depts = Context.Departments.ToList();
            ViewData["depts"] = depts;

            List<Course> crs = Context.Courses.ToList();
            ViewData["crs"] = crs;
            if (ModelState.IsValid==true)
             {
                OldI.name = NewI.name;
                OldI.address = NewI.address;
                OldI.DepartmentId= NewI.DepartmentId;
                OldI.image = NewI.image;    
                OldI.salary = NewI.salary;
                OldI.CourseId= NewI.CourseId;
                Context.SaveChanges();
                return RedirectToAction("ShowAllWithVModel");

            }
            return View("Edit", NewI);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(Context.Instructors.Find(id));
        }

       
        public IActionResult Delete2( int id)
        {
            Instructor ii = Context.Instructors.Find(id);
            Context.Remove(ii);
            Context.SaveChanges();
            return RedirectToAction("ShowAllWithVModel");
        }


    }
}






//public IActionResult ShowAllWithVModel(int id)
//{
//    InstructorJoinDepartmentViewModel vm = new InstructorJoinDepartmentViewModel();
//    Instructor instr = Context.Instructors.FirstOrDefault(s => s.DepartmentId == id);
//    Department dept = Context.Departments.FirstOrDefault(d => d.id == id);
//    vm.Iid = instr.id;
//    vm.Iname = instr.name;
//    vm.Did = dept.id;
//    vm.Dname = dept.Name;

//    return View(vm);
//}
