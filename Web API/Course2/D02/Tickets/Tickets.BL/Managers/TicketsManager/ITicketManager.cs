using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.DTO.Developers;
using Tickets.BL.DTO.Tickets;
using Tickets.DAL.Data.Models;

namespace Tickets.BL.Managers.TicketsManager
{
    public interface ITicketManager
    {
        public IEnumerable<TicketsDTO> GetAll();

        GetTicketDetailsDTO? GetTicketById (int id);
        public TicketsDTO? EditTicketById(int id, TicketsDTO newTicket);

        public int? DeleteTicketById(int id);

        public TicketsDTO? CreateNewTicket(TicketsDTO newTicket);

        public void AssignDevelopersToTickets(AssignDevelopersToTickets data);



    }
}
