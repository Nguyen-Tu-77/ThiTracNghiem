namespace QuizApp
{
    public class Question
    {
        private string content;

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    content = "Không có câu hỏi";
                }
                else
                {
                    content = value;
                }
            }
        }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }

        public string Option4 { get; set; }

        public string CorrectAnswer { get; set; }
    }
}