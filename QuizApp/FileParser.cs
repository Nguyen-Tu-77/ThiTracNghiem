using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace QuizApp
{
    //Class đọc đề thi từ txt 
    public class FileParser : IQuestionLoader
    {
        public List<Question> LoadQuestions(string path)
        {
            List<Question> questions = new List<Question>();

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i + 5 < lines.Length; i += 6)
            {
                Question q = new Question();
                q.Content = Regex.Replace(lines[i], @"^Câu\s*\d+\s*[:.-]*\s*", "").Trim();
                q.Option1 = lines[i + 1];

                q.Content = lines[i];
                q.Option1 = lines[i + 1];
                q.Option2 = lines[i + 2];
                q.Option3 = lines[i + 3];
                q.Option4 = lines[i + 4];

                q.CorrectAnswer = lines[i + 5].Replace("ANSWER:", "").Trim();

                questions.Add(q);
            }

            return questions;
        }
    }
}
