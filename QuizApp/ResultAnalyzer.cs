using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizApp
{
    //Class phân tích kết quả bài làm 
    public class ResultAnalyzer
    {
        public double CalculatePercentage(int score, int total)
        {
            return (double)score / total * 100;
        }

        public string GetRank(double percent)
        {
            if (percent >= 80)
                return "Giỏi";

            if (percent >= 65)
                return "Khá";

            if (percent >= 50)
                return "Trung Bình";

            return "Yếu";
        }
    }
}
