using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDP.Decorator
{
    internal class Defender:PlayerRole
    {
        public Defender(Player _player) : base(_player)
        {
        }

        public void Defend()
        {
            Console.WriteLine("Defend");
        }

        public override void PassBall()
        {
            Console.WriteLine("Defender passing");
        }
    }
}
