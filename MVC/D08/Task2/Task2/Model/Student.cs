using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [ForeignKey("Id")]
        public int? crs_id { get; set; }

        public virtual Course course { get; set; }

    }
}
