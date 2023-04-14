using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Data.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Many Tickets with Many Developers
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
