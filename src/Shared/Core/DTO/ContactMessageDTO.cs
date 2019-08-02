using System;

namespace Nina.DTO
{
    public class ContactMessageDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
