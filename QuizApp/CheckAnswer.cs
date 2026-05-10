using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizApp
{
    //Class chấm điểm bài thi 
    public class CheckAnswer : BaseManager
    {
        public int CalculateScore(List<Question> questions, Dictionary<int, string> answers)
        {
            int score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (answers.ContainsKey(i))
                {
                    if (answers[i] == questions[i].CorrectAnswer)
                    {
                        score++;
                    }
                }
            }

            return score;
        }
    }
}
