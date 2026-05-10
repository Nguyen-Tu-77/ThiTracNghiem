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

            for (int i = 0; i < questions.Count; i++)
{
    Console.WriteLine($"Câu {i + 1}: {questions[i].Content}");
    Console.WriteLine(questions[i].Option1);
    Console.WriteLine(questions[i].Option2);
    Console.WriteLine(questions[i].Option3);
    Console.WriteLine(questions[i].Option4);

    string answer = "";
    bool isValid = false;

    while (!isValid)
    {
        Console.Write("Đáp án của bạn (A, B, C, D): ");
        // Lưu lại vị trí con trỏ trước khi user nhập
        int cursorLeft = Console.CursorLeft;
        int cursorTop = Console.CursorTop;

        answer = Console.ReadLine()?.Trim().ToUpper();

        if (answer == "A" || answer == "B" || answer == "C" || answer == "D")
        {
            isValid = true;
            answerManager.SaveAnswer(i, answer);

            // --- KIỂM TRA VÀ HIỂN THỊ KẾT QUẢ CÓ MÀU TẠI CHỖ ---
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); // Xóa dòng vừa nhập
            Console.SetCursorPosition(0, cursorTop);

            string correctAnswer = questions[i].CorrectAnswer.Trim().ToUpper();
            if (answer == correctAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"=> Kết quả: {answer} - CHÍNH XÁC!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"=> Kết quả: {answer} - SAI! (Đáp án đúng: {correctAnswer})");
            }
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------");
        }
        else
        {
            // --- XỬ LÝ KHI NHẬP SAI (KHÔNG PHẢI A, B, C, D) ---
            
            // 1. Hiện thông báo lỗi màu đỏ ngay bên dưới
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vui lòng chọn trong các đáp án trên (A, B, C, D).");
            Console.ResetColor();

            Thread.Sleep(2000); // Đợi 2 giây

            // 2. Xóa dòng thông báo lỗi
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));

            // 3. Xóa nội dung user đã nhập sai trước đó và đưa con trỏ về chỗ cũ
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop); 
            
            // Vòng lặp while sẽ quay lại, user sẽ thấy như chưa từng có lỗi xảy ra
        }
    }
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
