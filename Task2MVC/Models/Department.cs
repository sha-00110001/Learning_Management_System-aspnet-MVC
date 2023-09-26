namespace Task2MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }

        public virtual ICollection<Instructor> Insructors { get; set; } = new HashSet<Instructor>();
        public virtual ICollection<Trainee> Trainees { get; set; } = new HashSet<Trainee>();

    }
}
