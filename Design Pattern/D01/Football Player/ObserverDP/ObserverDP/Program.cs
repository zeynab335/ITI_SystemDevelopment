namespace ObserverDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Football football = new Football();

            // intiallize 2 players
            Player p1 = new Player("Player 1" , football);
            Player p2 = new Player("Player 2", football); ;

            // intiallize referee
            Referee referee = new Referee(football);


            // Attach players and referee to publisher 
            football.AttachObserver(p1);
            football.AttachObserver(p2);
            football.AttachObserver(referee);



            football.SetBallPosition(new Position { X=10 , Y=20 , Z=30});

            // change postion of ball

            football.SetBallPosition(new Position { X = 20, Y = 30, Z = 40 });





        }
    }
}