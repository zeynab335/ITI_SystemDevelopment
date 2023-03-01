using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP.Builder
{
    public class Director
    {
        IBuilder builder;

        public void ConstructGround(IBuilder _builder)
        {
            builder= _builder;
            builder.BuildParts();
            builder.GetGround();
        }
    }
}
