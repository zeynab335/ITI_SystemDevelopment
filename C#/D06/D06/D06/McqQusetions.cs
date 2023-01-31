using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    internal class McqQusetions : Questions
    {
        public McqQusetions(int qID, string body, string header, int mark, string modelAnswer, int numOfChoices) : base(qID, body, header, mark, modelAnswer, numOfChoices)
        {
        }

        public void setChoicesOfQuestion(string[] Allchoices)
        {
            
                try
                {
                    for (int i = 0; i < Allchoices.Length; i++)
                    {
                        choices.setChoices(Allchoices[i], i);
                    }
                }
                catch
                {
                    Console.Write("Number of Choices not valid");
               }
            
        }
    }
}
