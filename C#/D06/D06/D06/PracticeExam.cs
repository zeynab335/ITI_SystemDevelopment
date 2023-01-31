using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    internal class PracticeExam : Exam
    {
        // shows the right answer after finishing taking the Exam 
        public PracticeExam(int ExId, int numOfQst, string exName) : base(ExId, numOfQst, exName)
        {
        }
        public override void ShowExam()
        {
            string question = "";
            string std_answer = "";
            bool flag = false;

            int i = 1;
            
            //* Get Id From Student
            Console.WriteLine("Enter Your Id");
            int stdId = 0;
            bool flag_std_id = false;
            do
            {
                flag_std_id  = int.TryParse(Console.ReadLine(), out stdId);
            }while(!flag_std_id);

            studentAnswers = new Answers(ExID, NumOfQst, stdId);


            foreach (Questions q in ExQuestions)
            {
                try
                {
                    question += q?.Body + '\n' + q?.getChoicesOfQuestion() + "\n\n";
                    Console.WriteLine(question);


                    do
                    {
                        //*Get Aswer From Student
                        Console.WriteLine("Enter Your Answer");
                        std_answer = Console.ReadLine();
                        if (std_answer == null || std_answer == "")
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                        }

                    } while (!flag);

                    studentAnswers?.setStdAnswer(q.QID, std_answer,i-1);
                    Console.WriteLine("Correct Answer is " + q.ModelAnswer);

                    Console.WriteLine("\n--------------------------------------------------------\n");

                    i++;
                    question = "";
                }
                catch
                {
                    Console.WriteLine("No Questions");
                }
               
            }

            //* Show Student Grades            
            Console.WriteLine("Student Id = " + stdId + " Grade = " + base.ExamCorrection(studentAnswers.getStdAnswers()));
        }



    }
}
