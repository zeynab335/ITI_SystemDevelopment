using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Tickets
{
    public interface ITicketsRepo
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetTicketById(int id);

        Ticket? GetTicketWithDevelopers(int id);

        public int? DeleteTicketById(int id);
        public Ticket? CreateNewTicket(Ticket newTicket);

        int SaveChanges();



    }
}
