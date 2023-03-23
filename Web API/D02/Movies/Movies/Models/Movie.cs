using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string Producer { get; set;}

        public int? Rate { get; set; }

        public virtual ICollection<Actor> Actors { get; set;} = new List<Actor>();
    }
}
