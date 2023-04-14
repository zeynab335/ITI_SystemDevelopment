using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.DTO.Departements;
using Tickets.BL.DTO.Developers;
using Tickets.BL.DTO.Tickets;
using Tickets.DAL.Data.Models;
using Tickets.DAL.Repos.Developers;
using Tickets.DAL.Repos.Tickets;

namespace Tickets.BL.Managers.TicketsManager
{
    public class TicketManager : ITicketManager
    {
        // inject Ticket Repo
        private readonly ITicketsRepo _ticketsRepo;
        private readonly IDeveloperRepo _developerRepo;

        public TicketManager(ITicketsRepo ticketsRepo, IDeveloperRepo developerRepo)
        {
            _ticketsRepo= ticketsRepo;
            _developerRepo= developerRepo;
        }
        public IEnumerable<TicketsDTO> GetAll()
        {
           var TicketsFromRepo = _ticketsRepo.GetAll();
            return TicketsFromRepo.Select(t => new TicketsDTO
            {
                Id = t.Id,
                Title = t.Title
            });
        }

        public GetTicketDetailsDTO? GetTicketById(int id)
        {
            Ticket? TicketFromRepo = _ticketsRepo.GetTicketById(id);

            if(TicketFromRepo == null)
            {
                return null;
            }

            return new GetTicketDetailsDTO
            {
                Id = TicketFromRepo.Id,
                Tittle = TicketFromRepo.Title,
                Description = TicketFromRepo.Description,
                Developers = TicketFromRepo.Developers.Select(d =>
                new DeveloperDTO{
                    Name = d.Name,
                    Id = d.Id
                }),
                Department = new DepartmentDTO
                {
                    Id = TicketFromRepo.department?.Id,
                    Name = TicketFromRepo.department?.Name??"",


                }
            };
        }

        public TicketsDTO? EditTicketById(int id, TicketsDTO newTicket)
        {
            Ticket? getTicket = _ticketsRepo.GetTicketById(id);
            if (getTicket is null)
            {
                return null;
            }
            getTicket.Title         = newTicket.Title;
            getTicket.Description   = newTicket.Description;
            
            _ticketsRepo.SaveChanges();
            return new TicketsDTO
            {
                Id = getTicket.Id,
                Title= newTicket.Title,
                Description= newTicket.Description
            };
        }

        public int? DeleteTicketById(int id)
        {
          int? isDeletedTicket = _ticketsRepo.DeleteTicketById(id);
            if(isDeletedTicket is null)
            {
                return null;
            }
            return isDeletedTicket;
        }

        public TicketsDTO? CreateNewTicket(TicketsDTO newTicket)
        {
            Ticket newTicket_ = new Ticket{
                Id = newTicket.Id,
                Title = newTicket.Title,
                Description = newTicket.Description
            };

            Ticket? createdTicket = _ticketsRepo.CreateNewTicket(newTicket_);

            if (createdTicket is null)
            {
                return null;
            }
            return newTicket;
        }

    
        public void AssignDevelopersToTickets(AssignDevelopersToTickets data)
        {
            Ticket? ticket = _ticketsRepo.GetTicketById(data.id);
            if (ticket is null)
            {
                return;
            }
            // clear Developers 
            ticket.Developers.Clear();

            // get developers by ids
            ICollection<Developer> Developers = _developerRepo.GetDeverlopersByIDs(data.TicketIDs).ToList();

            // assign new developers to tickets
            ticket.Developers = Developers;

            _ticketsRepo.SaveChanges();
        }

    }
}
