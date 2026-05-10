using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizApp
{
    //Class quản lý danh sách câu hỏi 
    public class Exam
    {
        public List<Question> Questions { get; set; }

        public Exam(List<Question> questions)
        {
            Questions = questions;
        }
    }
}
