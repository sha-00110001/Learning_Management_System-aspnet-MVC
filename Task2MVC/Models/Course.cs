using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task2MVC.Validator;

namespace Task2MVC.Models
{
    public class Course
    {

        public int ID { get; set; }

       
        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Course name must be between 2 and 30 characters.")]
        [UniqueName]
        public string name { get; set; }

        [Required(ErrorMessage = "Course degree is required.")]
        [Range(50, 500, ErrorMessage = "Course degree must be between 50 and 500.")]
       
        public int? degree { get; set; }


        [Required(ErrorMessage = "Course minimum degree is required.")]
        //[Range(0, 500, ErrorMessage = $"Course minimum degree must be between 0 and {this.degree/2}.")]   //Error here
        public int? mindgree { get; set; }


        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public virtual ICollection<CrsResult> CrsResults { get; set; } = new HashSet<CrsResult>();

    }
}
