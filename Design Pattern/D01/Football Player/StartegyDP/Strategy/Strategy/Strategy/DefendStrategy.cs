using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Strategy
{
    internal class DefendStrategy : TeamStrategy
    {
        public override void Play()
        {
            Console.WriteLine("play on Defend strategy");
        }
    }
}
