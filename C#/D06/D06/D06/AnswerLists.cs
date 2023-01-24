using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    // choices of each question
    internal class AnswerLists
    {
        private string[] choices;
        private int QID;

        public AnswerLists(int size, int qID)
        {
            QID = qID;
            choices = new string[size];
        }

        public void setChoices(string answer , int index)
        {
            choices[index] = answer;
        }

        public string[] getAllChoices()
        {
            return choices;
        }
    }
}
