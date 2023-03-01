using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP.Builder
{
    public class Product
    {
        //private Dictionary<string,string> parts;
        string background;
        string foreground;
        string details;

        public Product() { 
            //parts =  new Dictionary<string,string>();
        }
        //public void Add(string PartName , string PartValue)
        //{
        //    parts.Add(PartName , PartValue);
        //}

        public void AddBackground(string Value)
        {
            background = Value;
        }

        public void AddForeGround(string Value)
        {
            foreground = Value;

        }

        public void AddDetails(string Value)
        {
            details = Value;
        }
        public void Display()
        {

            if (Enum.TryParse(typeof(ConsoleColor), background, out object backgroundColor))
            {
                Console.BackgroundColor = (ConsoleColor)backgroundColor;
            }

            if (Enum.TryParse(typeof(ConsoleColor), foreground, out object foregroundColor))
            {
                Console.ForegroundColor = (ConsoleColor)foregroundColor;
            }
            
            Console.Clear();
            Console.WriteLine(details);

            

        }
    }
}
