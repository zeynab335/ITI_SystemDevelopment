using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.DTO.Departements;
using Tickets.BL.DTO.Developers;

namespace Tickets.BL.DTO.Tickets
{

    public record GetTicketDetailsDTO {
        public int Id { get; init; } 
        public string Tittle { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;

        public IEnumerable<DeveloperDTO> Developers { get; init; } = new List<DeveloperDTO>();
        public DepartmentDTO Department { get; init; } = new DepartmentDTO();

    };

}

