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
        private int NumOfChoices ;

        public AnswerLists(int size, int qID)
        {
            QID = qID;
            NumOfChoices = size;
            choices = new string[size];
        }

        public void setChoices(string answer , int index)
        {
        
            if (index < NumOfChoices){ 
                choices[index] = answer;
            }
        }

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
