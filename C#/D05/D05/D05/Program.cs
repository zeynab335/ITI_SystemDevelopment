namespace D05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //* To string override
            Point3D p = new Point3D(10, 10, 10);
            Console.WriteLine(p.ToString());

            string str = (string)p;
            Console.WriteLine(str);

            // 3. Read from the User the Coordinates for 2 point P1, P2
            // (Check the input, tryPares, Parse, Convert )
            Console.WriteLine("Enter Coordinates for 2 point P1, P2 \n ");
           
            //************* P1 ******************
            Console.WriteLine("Coordinates of P1 X= ");

            int P1_x;
            int.TryParse(Console.ReadLine() , out P1_x);

            Console.WriteLine("Coordinates of P1 Y= ");

            int P1_y;
            int.TryParse(Console.ReadLine(), out P1_y);

            Point P1 = new Point(P1_x, P1_y);
            Console.WriteLine(P1.ToString());


            //************* P2 ******************

            Console.WriteLine("Coordinates of P1 X= ");

            int P2_x;
            int.TryParse(Console.ReadLine(), out P2_x);

            Console.WriteLine("Coordinates of P1 Y= ");

            int P2_y;
            int.TryParse(Console.ReadLine(), out P2_y);

            //* Create P1
            Point P2 = new Point(P2_x, P2_y);
            Console.WriteLine(P2.ToString());


            if(P1 != P2)
            {
                Console.WriteLine("2 Points are not Equals ");
            }
            else
            {
                Console.WriteLine("2 Points are Equals ");

            }

            //*******************************
            //* Math
            Console.WriteLine(Math.Add(4, 5));
            Console.WriteLine(Math.Subtract(4, 5));
            Console.WriteLine(Math.Multiply(4, 5));
            Console.WriteLine(Math.Divide(4, 5));



            //*******************************
            //* NIC
            NIC n1 , n2;
            n1 = NIC.GNIC;
            n2 = NIC.GNIC;

            Console.WriteLine(n1);
            Console.WriteLine(n2);

            Console.WriteLine(NIC.GNIC.ToString());


            //* Duration
            Duration D1 = new Duration(11,80,125);
            //Console.WriteLine(D1.ToString());

            //* operator overloading
            Duration D2 = new Duration(3600);
            Duration D3;
            D3 = D1 + D2;
            //Console.WriteLine(D1.ToString());
            //Console.WriteLine(D2.ToString());

            //Console.WriteLine(D3.ToString());

            //D3 -= D1 ;
            //Console.WriteLine(D3.ToString());

            //D3 = D3 + 7800;
            //Console.WriteLine(D3.ToString());

            //Console.WriteLine(D1.ToString());
            //D3 = D1++;
            //Console.WriteLine(D1.ToString());
            //Console.WriteLine(D3.ToString());

            D3 = --D3;
            Console.WriteLine(D3.ToString());

            
            Console.WriteLine(D3 >= D1);
            Console.WriteLine(D3 < D1);
            Console.WriteLine(D3 > D1);

            //Duration D4 = new Duration(49,70,70);
            //DateTime date = (DateTime)D4;
            //Console.WriteLine(date.ToString());

            Duration D5 = new Duration(49, 70, 70);
            Console.WriteLine(D5.ToString());



        }






    }
}