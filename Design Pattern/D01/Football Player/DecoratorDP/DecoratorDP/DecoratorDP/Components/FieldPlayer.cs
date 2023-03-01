using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDP.Components
{
    public class FieldPlayer:Player
    {
        public override void PassBall()
        {
            Console.WriteLine("Field Player Pass the Ball ");
        }
    }
}
