using System;

namespace Nina.DTO
{
    public class ClassScheduleMessageDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
