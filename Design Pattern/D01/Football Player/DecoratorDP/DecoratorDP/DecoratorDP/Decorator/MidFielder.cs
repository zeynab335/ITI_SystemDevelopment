using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDP.Decorator
{
    internal class MidFielder: PlayerRole
    {
        public MidFielder(Player _player) : base(_player)
        {
        }

        public void Dribble()
        {
            Console.WriteLine("MiddleField Dribbling");
        }

        public override void PassBall()
        {
            Console.WriteLine("MiddleField passing");
        }
    }
}
