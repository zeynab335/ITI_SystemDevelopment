using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.BL.DTO.Departements
{
    public record DepartmentDTO
    {
        public int? Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
