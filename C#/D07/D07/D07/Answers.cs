using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D07
{   
    // all answers of Student of all questions on exam 
    internal class Answers
    {
        
        private int ExID;
        private int StdID;
        private Dictionary<int, string> studentAnswers ;


        public Answers(int exID  , int stdId)
        {
            ExID      = exID;
            StdID     = stdId;
            studentAnswers = new Dictionary<int, string>();
        }

        public void setStdAnswer(int qID, string answer)
        {
            studentAnswers[qID] = answer;
        }

        public string[] getStdAnswers()
        {
            string[] stdAnswers = new string[studentAnswers.Values.Count];
            int i = 0;
            foreach (var answer in studentAnswers.Values)
            {
                stdAnswers[i] = answer;
                i++;
            }
                
            return stdAnswers;
        }


    }
}
