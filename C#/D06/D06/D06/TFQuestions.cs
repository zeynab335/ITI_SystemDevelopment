using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    internal class TFQuestions : Questions
    {
        public TFQuestions(int qID, string body, string header, int mark, string modelAnswer) : base(qID, body, header, mark, modelAnswer)
        {
            // set choices in TF Constractor
            choices = new AnswerLists(2, qID);
            choices.setChoices("true", 0);
            choices.setChoices("false", 1);
        }

    }
}
