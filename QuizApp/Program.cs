using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            IQuestionLoader loader = new FileParser();

            List<Question> questions = loader.LoadQuestions("questions.txt");

            ShuffleManager shuffle = new ShuffleManager();

            questions = shuffle.ShuffleQuestions(questions);

            Exam exam = new Exam(questions);

            AnswerManager answerManager = new AnswerManager();

            for (int i = 0; i < exam.Questions.Count; i++)
            {
                Question q = exam.Questions[i];

                Console.WriteLine(q.Content);

                Console.WriteLine(q.Option1);
                Console.WriteLine(q.Option2);
                Console.WriteLine(q.Option3);
                Console.WriteLine(q.Option4);

                Console.Write("Đáp án: ");

                string answer = Console.ReadLine();

                answerManager.SaveAnswer(i, answer);

                Console.WriteLine();
            }

            CheckAnswer checker = new CheckAnswer();

            int score = checker.CalculateScore(exam.Questions, answerManager.UserAnswers);

            ResultAnalyzer analyzer = new ResultAnalyzer();

            double percent = analyzer.CalculatePercentage(score, exam.Questions.Count);

            string rank = analyzer.GetRank(percent);

            Console.WriteLine("===== KẾT QUẢ =====");

            Console.WriteLine("Điểm: " + score);

            Console.WriteLine("Phần trăm: " + percent + "%");

            Console.WriteLine("Xếp loại: " + rank);

            ReportExporter exporter = new ReportExporter();

            exporter.Export("result.txt", score, percent, rank);

            Console.ReadKey();
        }
    }
}
