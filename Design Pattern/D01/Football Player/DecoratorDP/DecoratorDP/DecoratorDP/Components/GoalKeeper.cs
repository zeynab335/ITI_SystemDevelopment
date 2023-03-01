using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDP.Components
{
    public class GoalKeeper:Player
    {
        public override void PassBall()
        {
            Console.WriteLine("GoalKeeper Pass the Ball ");
        }
    }
}
