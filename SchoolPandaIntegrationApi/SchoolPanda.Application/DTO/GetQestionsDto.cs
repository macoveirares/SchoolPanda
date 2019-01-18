namespace SchoolPanda.Application.DTO
{
    public class GetQestionsDto
    {
        public int UserId { get; set; }
        public int Type { get; set; }
        public int AddressedTo { get; set; }
        public string Question { get; set; }
    }
}