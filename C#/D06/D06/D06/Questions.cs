using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    internal abstract class Questions
    {
        // a Body, Marks, and Header
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public AnswerLists choices;

        public int QID { get; set; }
        public string ModelAnswer { get; set; }

        public Questions(int qID , string body , string header , int mark , string modelAnswer,int numOfChoices)
        {
            QID = qID;
            Body = body;
            Header = header;
            Mark =  mark;
            ModelAnswer = modelAnswer;
            choices = new AnswerLists(numOfChoices,qID);
        }

        public Questions(int qID, string body, string header, int mark, string modelAnswer)
        {
            QID = qID;
            Body = body;
            Header = header;
            Mark = mark;
            ModelAnswer = modelAnswer;
        }



        //public abstract void setChoicesOfQuestion(string[] Allchoices);
       
        

        public string getChoicesOfQuestion()
        {
            return choices?.getAllChoices();

        }

        public virtual int MarkQuestion(string std_answer)
        {
            
            if(std_answer.Trim().ToLower().Equals(ModelAnswer.Trim().ToLower()))
            {
                return Mark;
            }
            return 0;
        }



    }
}
