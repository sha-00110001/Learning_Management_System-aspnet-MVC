using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2MVC.Models
{
    public class Trainee
    {

        public int Id { get; set; }
        public string? name { get; set; }
        public string? image { get; set; }
        public int? grade { get; set; }
        public string? address { get; set; }


        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<CrsResult> CrsResults { get; set; } = new List<CrsResult>();

    }
}
