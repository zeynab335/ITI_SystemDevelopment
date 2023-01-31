using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace D06
{
    internal abstract class Exam
    {
        public int ExID { get; set; }
        public string ExName { get; set; }
        public int ExDuration { get; set; }
        public int NumOfQst {get; set; }
        
        internal Questions[] ExQuestions;
        internal Answers studentAnswers;


        public Exam(int ExId,int numOfQst , string exName)
        {
            ExID = ExId;
            ExName = exName;
            NumOfQst= numOfQst;
            ExQuestions = new Questions[numOfQst];
        }

        public void setQuestions(Questions[] q)
        {
            try
            {
                if (q != null)
                {
                    ExQuestions = q;

                }
                else
                {
                    throw new Exception();
                }
                
            }
            catch
            {
                Console.WriteLine("questions is not added to exam");
            }
        }


        public virtual void ShowExam()
        {
            throw new NotImplementedException();
        }

        

        public string ExamCorrection(string[] std_answers)
        {
            int Marks = 0;
            int TotalMarks = 0;

            // to get total marks of exam
            for (int i = 0; i < ExQuestions?.Length; i++)
            {
                TotalMarks += ExQuestions[i].Mark;
            }
             for (int i=0; i< std_answers?.Length; i++)
             {
                string st = std_answers[i] ?? "";
                if (!st.Equals(""))
                {
                    Marks += ExQuestions[i]?.MarkQuestion(st) ?? 0;
                }
             }

            return (Marks*100/TotalMarks) + "%";
        }

        public override string ToString()
        {
            foreach (var item in ExQuestions)
            {
                Console.WriteLine(item.getChoicesOfQuestion() + "\n");
            }
            return " ";
        }

    }
}
