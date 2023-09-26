using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Task2MVC.Models;
namespace Task2MVC.Validator
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string name = value.ToString();
            UniversityContext context = new UniversityContext();
            Course emp = context.Courses.FirstOrDefault(e => e.name == name);
            if (emp == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Course already exists");
        }

    }
}