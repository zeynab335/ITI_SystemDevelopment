using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D07
{
    internal class QuestionList : List<Questions>
    {
        //* Read All Data from these files
        private string absoluteQuestionPath = "H:\\ITI\\GitHup\\ITI_SystemDevelopment\\C#\\D07\\D07\\Data\\QuestionFiles\\";
        private string absoluteAnswerPath = "H:\\ITI\\GitHup\\ITI_SystemDevelopment\\C#\\D07\\D07\\Data\\AnswerFiles\\";
        private string absoluteModelAnswerPath = "H:\\ITI\\GitHup\\ITI_SystemDevelopment\\C#\\D07\\D07\\Data\\ModelAnswes\\";

        // to append all data into these files
        private string AllQuestions = @"H:\ITI\GitHup\ITI_SystemDevelopment\C#\D07\D07\Data\QuestionFiles\File.txt";
        private string AllAnswers = @"H:\ITI\GitHup\ITI_SystemDevelopment\C#\D07\D07\Data\AnswerFiles\File.txt";
        private string AllModelAnswers = @"H:\ITI\GitHup\ITI_SystemDevelopment\C#\D07\D07\Data\ModelAnswes\File.txt";


        private string[] filesUrl = new string[] { "AllChoices.txt", "Mcq.txt", "TF.txt" };
        public QuestionList() : base()
        {
            if ((File.Exists(AllQuestions) && File.Exists(AllAnswers) && File.Exists(AllModelAnswers)))
            {
                File.WriteAllText(AllQuestions, string.Empty);
                File.WriteAllText(AllAnswers, string.Empty);
                File.WriteAllText(AllModelAnswers, string.Empty);
                LoadQuestion_Answers();
            }
        }
        

        // in the first [check if files AllQuestion | AllAsnwers exsist or not]
        private void LoadQuestion_Answers()
        {
            foreach (string file_path in filesUrl)
            {
                try
                {
                    string questionPath = absoluteQuestionPath + file_path;
                    string answerPath = absoluteAnswerPath + file_path;
                    string modelAnswerPath = absoluteModelAnswerPath + file_path;

                    if ((File.Exists(AllQuestions) && File.Exists(AllAnswers) && File.Exists(AllModelAnswers)))
                    {
                        TextReader questionReader = File.OpenText(questionPath);
                        TextReader answerReader = File.OpenText(answerPath);
                        TextReader modelAnswerReader = File.OpenText(modelAnswerPath);
                        
                        
                        TextWriter question_writer = File.AppendText(AllQuestions);
                        TextWriter answer_writer = File.AppendText(AllAnswers);
                        TextWriter modelAnswer_writer = File.AppendText(AllModelAnswers);

                        string question, answer, modelanswer;
                        Random random = new Random();
                        int qid;

                        while (((question = questionReader?.ReadLine()) != null) && ((answer = answerReader?.ReadLine()) != null) && ((modelanswer = modelAnswerReader?.ReadLine()) != null))
                        {
                            qid = random.Next(100);
                            AnswerLists answers = new(answer.Split(',').Length, qid);
                            answers.setChoices(answer.Split(','));


                            Questions question_data = new Questions(qid, question, "Header", 10, modelanswer, answers);

                            question_writer.WriteLine(question);
                            answer_writer.WriteLine(answer);
                            modelAnswer_writer.WriteLine(modelanswer);


                            base.Add(question_data);
                        }


                        questionReader.Close();
                        answerReader.Close();
                        modelAnswerReader.Close();

                        question_writer.Close();
                        answer_writer.Close();
                        modelAnswer_writer.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public new void Add(Questions question_data)
        {
            try {

                if ((File.Exists(AllQuestions) && File.Exists(AllAnswers) && File.Exists(AllModelAnswers)))
                {
                    TextWriter question_writer = File.AppendText(AllQuestions);
                    TextWriter answer_writer = File.AppendText(AllAnswers);
                    TextWriter modelAnswer_writer = File.AppendText(AllModelAnswers);

                    Console.WriteLine(String.Join(",", question_data.getChoicesOfQuestion().Split("\n")));
                    string ans = String.Join(",",question_data.getChoicesOfQuestion().Split("\n"));
                    // add question & answer & modelanswer into Globalfiles 
                    question_writer.WriteLine($"{question_data.QID} ) {question_data.Body}");
                    answer_writer.WriteLine(ans);
                    modelAnswer_writer.WriteLine(question_data.ModelAnswer);



                    question_writer.Close();
                    answer_writer.Close();
                    modelAnswer_writer.Close();

                    base.Add(question_data);
                }
                else
                {
                    Console.WriteLine("not exsist");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        
    }

}


