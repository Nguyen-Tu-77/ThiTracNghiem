using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuizApp
{
    //Class xuất file kết quả bài thi 
    public class ReportExporter
    {
        public void Export(
        string path,
        int score,
        double percent,
        string rank)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("KẾT QUẢ THI");
                writer.WriteLine("Điểm: " + score);
                writer.WriteLine("Phần trăm: " + percent + "%");
                writer.WriteLine("Xếp loại: " + rank);
            }
        }
    }
}
