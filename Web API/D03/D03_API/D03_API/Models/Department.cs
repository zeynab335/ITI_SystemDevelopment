using System.ComponentModel.DataAnnotations;

namespace D03_API.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

       
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Location { get; set; }
        
        [MaxLength(100)]
        public string? Description { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    }
}
