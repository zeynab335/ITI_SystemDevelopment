using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task2.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Topic { get; set; }

        [Required]
        public int CourseGrade { get; set; }

        public virtual List<Student> Students { get; set; } = new();


    }
}
