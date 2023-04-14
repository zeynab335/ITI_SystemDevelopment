using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Context;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Developers
{
    public class DeveloperRepo : IDeveloperRepo
    {
        private readonly TicketsContext _context;
        public DeveloperRepo(TicketsContext context) {
            _context = context;
        }
        public IEnumerable<Developer> GetDevelopers()
        {
            return _context.Set<Developer>();
        }

        public IEnumerable<Developer> GetDeverlopersByIDs(int[] ids)
        {
            return _context.Set<Developer>().Where(
                 d => ids.Contains(d.Id));
        }

    }
}
