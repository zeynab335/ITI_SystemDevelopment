using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public enum GenderEnum
    {
        Female , Male
    }
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public  GenderEnum Gender { get; set; }

        public int? Age { get; set; }

        [MaxLength(50)]
        public string? Address { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [ForeignKey("Movie")]
        public int MovieID { get; set;}

        public virtual Movie? MovieDetails { get; set; }

    }
}
