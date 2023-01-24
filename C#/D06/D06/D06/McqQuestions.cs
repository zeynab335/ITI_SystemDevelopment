using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    internal class McqQuestions : Questions
    {
        public McqQuestions(int qID, string body, string header, int numOfQst) : base(qID, body, header, numOfQst)
        {
        }
    }
}
