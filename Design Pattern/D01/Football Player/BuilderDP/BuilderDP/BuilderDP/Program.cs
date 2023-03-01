using BuilderDP.Builder;

namespace BuilderDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder1 = new BuilderMulti();
            IBuilder builder2 = new BuilderSingle();


            Director d1 = new();
            d1.ConstructGround(builder1);
            d1.ConstructGround(builder2);


            Console.ReadLine();
           
        }
    }
}