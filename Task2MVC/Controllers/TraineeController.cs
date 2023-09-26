using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2MVC.Models;
using Task2MVC.ViewModels;
using static NuGet.Packaging.PackagingConstants;

namespace Task2MVC.Controllers
{
    
    public class TraineeController : Controller
    {
        UniversityContext Context = new UniversityContext();

        public IActionResult ShowResult(int id , int crs)  //trainee id , crs id
        {
            TraineeJoinCrsjoinRes vm = new TraineeJoinCrsjoinRes();
            Trainee t = Context.Trainees.FirstOrDefault(s => s.Id == id);
            CrsResult cr = Context.CrsResults.FirstOrDefault(s => s.traineeid == id && s.crsid == crs);
            Course c = Context.Courses.FirstOrDefault(s => s.ID == crs);
            vm.traineeID = t.Id;
            vm.traineeName = t.name;
            vm.Degree = cr.degree;
            vm.crsName = c.name;
            
            vm.color = (vm.Degree >= c.mindgree) ? "green" : "red" ;


            return View(vm);
        }
    }
}
