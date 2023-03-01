using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDP
{
    public class Ball
    {
        //private ICollection<Player> Players;
        //private Referee Referee;

        /// <summary>
        /// list of all subjects
        /// </summary>
        internal ICollection<IObserver> Subjects;

        public Ball(){

            Subjects = new HashSet<IObserver>();
            //Referee= new Referee();
        }
    
        public void AttachObserver(IObserver subject)
        {
            Subjects.Add(subject);
        }

        public void DetachObserver(IObserver subject)
        {
            Subjects.Remove(subject);
        }
        public void NotifyObserver()
        {
            foreach(var subject in Subjects)
            {
                subject.Update();
            }
        }

    }



}
