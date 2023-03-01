using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDP.Decorator
{
    internal class Forward : PlayerRole
    {
        public Forward(Player _player) : base(_player)
        {
        }
        public void ShootGoal()
        {
            Console.WriteLine("Forward Shooting");
        }

        public override void PassBall()
        {
            Console.WriteLine("Forward passing");
            player.PassBall();
        }
    }
}
