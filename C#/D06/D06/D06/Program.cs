namespace D06
{
    enum ExType
    {
        PracticeExam , FinalExam
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            McqQusetions q1 = new McqQusetions(1, "Q. What are the three important manipulations done in for loop on a loop variable? Updation, Incrementation, Initialization", "Qusetion", 10, "Initialization, Testing, Updation", 3);
            string[] choices_Q1 = new string[3] { "Initialization, Testing, Updation" , "Testing, Updation, Testing" , "Initialization, Testing, Incrementation" };
            q1.setChoicesOfQuestion(choices_Q1);

            ChooseAllQuestions q2 = new ChooseAllQuestions(2, "Q. A function definition expression can be called as: ", "Qusetion", 10, "Function prototype , Function literal ", 3);
            string[] choices_Q2 = new string[3] { "Function prototype", "Function literal", "Function calling" };
            q2.setChoicesOfQuestion(choices_Q2);

            TFQuestions q3 = new TFQuestions(3, "Q. A function definition expression can be called as: body and html ", "Qusetion", 10, "True");
            //string[] choices_Q3 = new string[2] { "True", "False" };
            //q3.setChoicesOfQuestion(choices_Q3);


            Questions[] All_Questions = new Questions[3];
            //tf , mcq , chooseAll

            All_Questions[0] = q1;
            All_Questions[1] = q2;
            All_Questions[2] = q3;


            ExType ex;
            bool value;
            Console.WriteLine("Enter Type of Exam => FianlExam || PracticeExam");
            do
            {
                value = Enum.TryParse(Console.ReadLine(), out ex);
            } while (!value);

            FinalExam e1 = default;
            PracticeExam e2 = default;
            
            if (ExType.FinalExam.Equals(ex))
            {
                e1 = new FinalExam(1, 5, "OS");
                e1.setQuestions(All_Questions);
                e1.ShowExam();
                //Console.WriteLine(e1.ShowExam());

            }
            else if(ExType.PracticeExam.Equals(ex))
            {
                e2 = new PracticeExam(1, 5, "OS");
                e2.setQuestions(All_Questions);
                e2.ShowExam();
                //Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Questions");
            }


           




        }
    }
}