using Strategy.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Structure
{
    public class Team
    {
        TeamStrategy teamStrategy;
        public void SetStrategy(TeamStrategy s)
        {
            teamStrategy = s;
        }

        public void PlayGame()
        {
            Console.WriteLine("Play Game....");
            teamStrategy.Play();
        }
    }
}
