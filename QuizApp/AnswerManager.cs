using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizApp
{
    //Class lưu đáp án của người dùng 
    public class AnswerManager
    {
        public Dictionary<int, string> UserAnswers
        = new Dictionary<int, string>();

        public void SaveAnswer(int index,
                               string answer)
        {
            if (UserAnswers.ContainsKey(index))
            {
                UserAnswers[index] = answer;
            }
            else
            {
                UserAnswers.Add(index, answer);
            }
        }
    }
}
