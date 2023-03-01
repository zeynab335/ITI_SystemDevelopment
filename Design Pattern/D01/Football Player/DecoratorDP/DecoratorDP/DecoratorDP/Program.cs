using DecoratorDP.Components;
using DecoratorDP.Decorator;

namespace DecoratorDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player fieldPlayer = new FieldPlayer();
            
            fieldPlayer = new Forward(fieldPlayer);

            fieldPlayer.PassBall();
            if (fieldPlayer is Forward fwd)
            {
                fwd.ShootGoal();
            }

            Console.WriteLine("--------------");

            Player goalkeeper = new GoalKeeper();

            goalkeeper = new MidFielder(goalkeeper);

            goalkeeper.PassBall();
            if (goalkeeper is MidFielder md)
            {
                md.Dribble();
            }
        
        }
    }
}