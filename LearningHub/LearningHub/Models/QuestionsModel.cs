namespace LearningHub.Models
{
    public class AddQuestionModel
    {
        public string Question { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public int AddressedTo { get; set; }
    }
}