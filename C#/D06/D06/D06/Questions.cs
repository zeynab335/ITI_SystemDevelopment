using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    internal class Questions
    {
        // a Body, Marks, and Header
        public string Header { get; set; }
        public string Body { get; set; }
        public int[] Marks { get; set; }

        public AnswerLists answers;
        public int QID { get; set; }
        

        // Marks => correction
        // Answers => Answer of students || answers of all questions in exam

        public Questions(int qID , string body , string header , int numOfQst )
        {
            QID = qID;
            Body = body;
            Header = header;
            Marks = new int[numOfQst] ;
        }

        public void setAnswerOfQuestions(AnswerLists[] AllAns , int[] index , int size)
        {
            for(int i=0; i<size; i++)
            {
                answers.setAnswers(AllAns[i] , index[i]);
            }
         
        }

        public Answers getAnswerOfQuestions()
        {
            return answers;

        }



    }
}
