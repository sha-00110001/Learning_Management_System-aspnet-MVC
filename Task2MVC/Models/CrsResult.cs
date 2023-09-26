using System.ComponentModel.DataAnnotations.Schema;

namespace Task2MVC.Models
{
    public class CrsResult
    {

        public int Id { get; set; }
        public int? degree { get; set; }

        [ForeignKey("crs")]
        public int crsid { get; set; }

        [ForeignKey("trainee")]
        public int traineeid { get; set; }

        public virtual Course crs { get; set; }
        public virtual Trainee trainee { get; set; }
      

        

    }
}
