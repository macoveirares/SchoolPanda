namespace SchoolPanda.Application.DTO
{
    public class AddQuestion
    {
        public string Question { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public int AddressedTo { get; set; }
    }
}