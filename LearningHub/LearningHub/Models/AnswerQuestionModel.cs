namespace LearningHub.Models
{
    public class AnswerQuestionModel
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int Type { get; set; }
        public int ProfId { get; set; }
    }
}