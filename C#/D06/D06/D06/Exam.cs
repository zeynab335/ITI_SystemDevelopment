using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace D06
{
    internal class Exam
    {
        private int ExID;
        private string ExName;
        private int ExDuration;
        private int NumOfQst;

        private Questions[] ExQuestions;


        public Exam(int ExId,int numOfQst , string exName)
        {
            ExID = ExId;
            ExName = exName;
            NumOfQst= numOfQst;
            ExQuestions = new Questions[numOfQst];
        }

        public void setQuestions(int index , Questions q)
        {
            try
            {

                if (index < NumOfQst)
                {
                    ExQuestions[index] = q;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("questions is not added to exam");
            }
        }
    }
}
