namespace Quzzing.Models
{
    public class Question
    {
        public string QuestionTitle { get; set; }
        public IEnumerable<string> Options { get; set; } = new List<string>();
        public string Answer { get; set; } = string.Empty;
    }
}
