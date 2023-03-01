using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObserverDP
{
    public class Player : IObserver
    {
        private Football football;  
        public string PlayerName { set; get; }
     
        public Player(string name, Football footBall)
        {
            PlayerName= name;
            football = footBall;
        }
        


        public void Update()
        {
            Console.WriteLine($" Player {PlayerName} \n position of ball is changed {football.GetBallPosition()?.X} , {football.GetBallPosition()?.Y} , {football.GetBallPosition()?.Z} ");
            Console.WriteLine("\n*****************************\n");
        }
    }
}
