using Task2MVC.Models;

namespace Task2MVC.ViewModels
{
    public class InstructorJoinDepartmentViewModel
    {
        public List<Department> Dept { get; set; }
        public List<Instructor> Instru { get; set; }
        public List<Course> Crs { get; set; }
    }
}