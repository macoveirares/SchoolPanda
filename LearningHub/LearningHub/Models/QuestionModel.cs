namespace LearningHub.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
    }
}
