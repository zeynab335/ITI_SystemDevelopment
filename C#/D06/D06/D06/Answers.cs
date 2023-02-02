using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{   
    // all answers of Student of all questions on exam 
    internal class Answers
    {
      
        private string[] StdAnswers;
        private int[] QID;
        private int ExID;
        private int StdID;


        public Answers(int exID , int NumOfQst , int stdId)
        {
            ExID      = exID;
            StdID     = stdId;
            StdAnswers = new string[NumOfQst];
            QID       = new int[NumOfQst];
        }

        public void setStdAnswers(int[] qID, string[] answer)
        {
            StdAnswers = answer;
            QID = qID;
        }

        public void setStdAnswer(int qID, string answer, int index)
        {
            StdAnswers[index] = answer;
            QID[index] = qID;
        }

        public string[] getStdAnswers()
        {
            return StdAnswers;
        }


    }
}
