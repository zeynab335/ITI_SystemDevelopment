using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Data.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //1 Department with Many Tickets
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
            
    }
}
