using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace D07
{
    // choices of each question
    internal class AnswerLists
    {
        //protected string[] choices;
        protected List<string> choices;
        private int QID;
        private int NumOfChoices;

        public AnswerLists(int size, int qID)
        {
            QID = qID;
            NumOfChoices = size;
            //choices = new string[size];
            choices = new List<string>();
        }

        public AnswerLists(int qID)
        {
            QID = qID;
            //choices = new List<string>();
            choices = new List<string>();
        }



        //public void setChoices(string answer, int index)
        //{
        //    if (index < NumOfChoices)
        //    {
        //        choices[index] = answer;
        //    }
        //}
        public void setChoices(string[] answer)
        {
            foreach (string ans in answer)
            {
                choices.Add(ans);
            }
        }

        //public void setChoices(List<string> answers)
        //{

        //    choices = answers;
        //}



        public string getAllChoices()
        {
            string Q_choices = "";
            foreach (string choice in choices)
            {
                // last element of choices array
                try
                {
                    if (choice.Equals(choices[^1]))
                    {
                        Q_choices += choice;
                    }
                    else { Q_choices += choice + "\n"; }
                }
                catch {
                    Console.WriteLine("Choices not available ");
                }
                
            }
            return Q_choices;
        }
    }
}
