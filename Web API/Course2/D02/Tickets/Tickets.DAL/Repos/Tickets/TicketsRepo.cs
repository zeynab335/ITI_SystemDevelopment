using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Context;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Tickets
{
    public class TicketsRepo : ITicketsRepo
    {
        private readonly TicketsContext _context;
        public TicketsRepo(TicketsContext context ) {
            _context = context;
        }    
        public IEnumerable<Ticket> GetAll()
        {
            return _context.Set<Ticket>();
        }

        public Ticket? GetTicketById(int id)
        {
            return _context.Set<Ticket>().Include(t=>t.Developers ).Include(t=>t.department).FirstOrDefault(t => t.Id == id);

        }

        public Ticket? GetTicketWithDevelopers(int id)
        {
            return _context.Set<Ticket>()
               .Include(t => t.Developers)
               .FirstOrDefault(d => d.Id == id);
        }

        public Ticket? CreateNewTicket(Ticket newTicket)
        {
            try
            {
                _context.Tickets.Add(newTicket);
                _context.SaveChanges();

                return newTicket;
            }
            catch 
            {
                return null;
            }
        }

        public int? DeleteTicketById(int id)
        {
           Ticket? DeletedTicket =  _context.Set<Ticket>().Find(id);
            if(DeletedTicket is null)
            {
                return null;
            }
            _context.Tickets.Remove(DeletedTicket);
            return SaveChanges();
        }

        // edit ticket with Developers ==> tiket-id , array-of-developers
      



        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}
