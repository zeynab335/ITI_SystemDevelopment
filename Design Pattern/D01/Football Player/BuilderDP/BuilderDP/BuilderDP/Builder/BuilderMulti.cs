using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP.Builder
{
    public class BuilderMulti : IBuilder
    {
        Product product;

        public BuilderMulti()
        {
            product = new Product();    
        }

        public void BuildParts()
        {
            product.AddBackground("Blue");
            product.AddForeGround("White");
            product.AddDetails("Build Multi Part");
        }

        public void GetGround()
        {
            product.Display();
        }
    }
}
