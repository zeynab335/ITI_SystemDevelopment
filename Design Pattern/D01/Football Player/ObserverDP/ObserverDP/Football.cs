using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDP
{
    public class Football:Ball
    {
        private Position myPosition { get; set; }

        public Position GetBallPosition() => myPosition;

        public void SetBallPosition(Position p)
        {
            if(p.X != myPosition?.X || p.Y != myPosition?.Y || p.Z != myPosition?.Z)
            {
                myPosition = p;
             
                NotifyObserver();
            }

        }


    }
}
