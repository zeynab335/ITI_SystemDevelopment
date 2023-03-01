using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP.Builder
{
    public class BuilderSingle:IBuilder
    {
        Product product;

        public BuilderSingle()
        {
            product = new Product();
        }
        public void BuildParts()
        {
            product.AddBackground("Red");
            product.AddForeGround("Black");
            product.AddDetails("Build Single Part");

        }
        public void GetGround()
        {
            product.Display();
        }
    }
}
