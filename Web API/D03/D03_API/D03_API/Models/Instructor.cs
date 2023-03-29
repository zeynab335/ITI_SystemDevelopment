using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D03_API.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SSN { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]

        public string Password { get; set; }


        [Required]
        public string Phone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DOB { get; set; }
            
        public int Age { get; set; }


        [ForeignKey("Dept")]
        public int? Dept_Id { get; set; }

        public virtual Department? Dept { get; set; }
    }
}
