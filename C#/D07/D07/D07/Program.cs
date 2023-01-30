namespace D07
{
    enum ExType
    {
        PracticeExam, FinalExam
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            McqQusetions q1 = new McqQusetions(1, "Q. What are the three important manipulations done in for loop on a loop variable? Updation, Incrementation, Initialization", "Qusetion", 10, "Initialization, Testing, Updation", 3);
            string[] choices_Q1 = new string[3] { "Initialization, Testing, Updation", "Testing, Updation, Testing", "Initialization, Testing, Incrementation" };
            q1.setChoicesOfQuestion(choices_Q1);

            ChooseAllQuestions q2 = new ChooseAllQuestions(2, "Q. A function definition expression can be called as: ", "Qusetion", 10, "Function prototype , Function literal ", 3);
            string[] choices_Q2 = new string[3] { "Function prototype", "Function literal", "Function calling" };
            q2.setChoicesOfQuestion(choices_Q2);


           QuestionList All_Questions = new QuestionList();
            All_Questions.Add(q2);
            
            //* Select type of Exam from End User
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
            }
            else if (ExType.PracticeExam.Equals(ex))
            {
                e2 = new PracticeExam(1, 5, "OS");
                e2.setQuestions(All_Questions);
                e2.ShowExam();
            }
            else
            {
                Console.WriteLine("No Questions");
            }

        }
    }
}