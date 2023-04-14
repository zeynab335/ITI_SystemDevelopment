using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Data.Models
{
    public class Ticket
    {
        // Ticket (Id, Description, Title)
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public int? DeptId { get; set;}

        public Department? department { get; set; }

        //Many Tickets with Many Developers
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    }
}
