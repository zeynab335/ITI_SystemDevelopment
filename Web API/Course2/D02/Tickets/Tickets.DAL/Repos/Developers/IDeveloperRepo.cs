using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Developers
{
    public interface IDeveloperRepo
    {
        public IEnumerable<Developer> GetDevelopers();

        public IEnumerable<Developer> GetDeverlopersByIDs(int[] ids);

    }
}
