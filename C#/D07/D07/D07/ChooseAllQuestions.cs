﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D07
{
    internal class ChooseAllQuestions : Questions
    {
        public ChooseAllQuestions(int qID, string body, string header, int mark, string modelAnswer, int numOfChoices) : base(qID, body, header, mark, modelAnswer, numOfChoices)
        {
        }

        public void setChoicesOfQuestion(string[] Allchoices)
        {
            try

            {
                choices.setChoices(Allchoices);
               
            }
            catch
            {
                Console.Write("Number of Choices not valid");
            }
        }

        public override int MarkQuestion(string std_answer)
        {
            string[] ModelAnswers = ModelAnswer.Split(',');
            string[] stdAnswers = std_answer.Split(',');

            bool flag = false;
            
            for (int i =0; i< stdAnswers?.Length ; i++)
            {

                if (stdAnswers[i].Trim().ToLower().Equals(ModelAnswers[i].Trim().ToLower()))
                {
                    Console.WriteLine("correct");
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }

            return flag ? Mark : 0;
        }

    }
}