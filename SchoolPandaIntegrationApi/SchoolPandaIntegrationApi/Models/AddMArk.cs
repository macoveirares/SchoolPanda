using System;

namespace SchoolPandaIntegrationAPI.Models
{
    public class AddMArk
    {
        
        public int UserId { get; set; }
       
        public int CourseId { get; set; }
       
        public double Points { get; set; }
     
        public DateTime AddedDate { get; set; }
    }
}
