namespace LearningHub.Application.DTO
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
    }
}