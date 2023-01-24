using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{   
    // all answers of all questions on exam
    internal class Answers
    {

        private AnswerLists[] AnswersOfExams;

        private int ExID;

        public Answers(int size, int exID)
        {
            ExID = exID;
            AnswersOfExams = new AnswerLists[size];
        }

        public void setAnswers(AnswerLists ans , int index)
        {
            AnswersOfExams[index] = ans;
        }

        public AnswerLists[] getAnswers()
        {
            return AnswersOfExams;
        }


    }
}
