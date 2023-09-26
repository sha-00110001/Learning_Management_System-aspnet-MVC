using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Task2MVC.Models
{
    public class Instructor
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("[a-zA-Z]{3,30}",
        ErrorMessage = "Invalid, name must not contain numbers.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        public string? name { get; set; }
        public string? image { get; set; }


        [Required(ErrorMessage = "Salary is required.")]
        [Range(2000, 50000, ErrorMessage = "Salary must be between 2000 and 50000.")]

        public double? salary { get; set; }

        [RegularExpression("[a-zA-Z]{3,30}",
        ErrorMessage = "Invalid, address must not contain numbers and atleast 3 characters")]

        public string? address { get; set; }

        [DisplayName("Department ID ")]
        [ForeignKey("Dept")]
        public int DepartmentId { get; set; }

        [DisplayName("Course ID ")]
        [ForeignKey("Crs")]
        public int CourseId { get; set; }

        
        public virtual Department? Dept { get; set; }
       
        public virtual Course? Crs { get; set; }


    }
}
