using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.BL.DTO.Developers;
using Tickets.BL.DTO.Tickets;
using Tickets.BL.Managers.TicketsManager;

namespace Tickets_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        // inject TicketManager
        private readonly ITicketManager _ticketManager;
        public TicketsController(ITicketManager ticketManager) {
            _ticketManager = ticketManager;
        }
        [HttpGet]
        public ActionResult<List<TicketsDTO>> Get()
        {
            return _ticketManager.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<GetTicketDetailsDTO> GetTicketDetails(int id)
        {
            GetTicketDetailsDTO? ticket = _ticketManager.GetTicketById(id);
            if (ticket is null)
            {
                return NotFound();
            }
            return ticket;

        }


        [HttpPut]
        public ActionResult<TicketsDTO> Edit(int id, TicketsDTO tickets)
        {
            TicketsDTO? ticket = _ticketManager.EditTicketById(id, tickets);
            if (ticket is null)
            {
                return NotFound();
            }
            return ticket;

        }


        [HttpPost]
        public ActionResult<TicketsDTO> Create(TicketsDTO tickets)
        {
            TicketsDTO? ticket = _ticketManager.CreateNewTicket(tickets);
            if (ticket is null)
            {
                return NotFound();
            }
            return Ok(ticket);

        }

        [HttpDelete]
        public ActionResult<TicketsDTO> Delete(int id)
        {
            int? isDeleted = _ticketManager.DeleteTicketById(id);
            if (isDeleted is null)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpPost]
        [Route("{id}")]
        public ActionResult EditDevelopes(AssignDevelopersToTickets data) {
            _ticketManager.AssignDevelopersToTickets(data);
            return NoContent();
        }

    }
}
