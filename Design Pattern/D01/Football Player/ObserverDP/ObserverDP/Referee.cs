using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDP
{
    public class Referee:IObserver
    {
        private Football football;

        public Referee(Football footBall)
        {
            football = footBall;
        }

        public void Update()
        {
            Console.WriteLine($" Referee \n position of ball is changed {football.GetBallPosition()?.X} , {football.GetBallPosition()?.Y} , {football.GetBallPosition()?.Z} ");
            Console.WriteLine("\n*****************************\n");

        }

    }
}
