using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizApp
{
    //Class trộn câu hỏi và đảo đáp án 
    public class ShuffleManager : BaseManager
    {
        private Random random = new Random();

        public List<Question> ShuffleQuestions(List<Question> questions)
        {
            return questions.OrderBy(x => random.Next()).ToList();
        }
    }
}
