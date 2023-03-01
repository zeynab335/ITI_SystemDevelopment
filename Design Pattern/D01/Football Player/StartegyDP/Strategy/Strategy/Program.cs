using Strategy.Strategy;
using Strategy.Structure;

namespace ObserverDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
           DefendStrategy df = new DefendStrategy();

            Team team = new Team();
            team.SetStrategy(df);
            team.PlayGame();

            Console.WriteLine("\n------------ Change Strategy------------\n");
            // change strategy
            AttackStrategy attackStrategy = new AttackStrategy();
            team.SetStrategy(attackStrategy);
            team.PlayGame();


        }
    }
}