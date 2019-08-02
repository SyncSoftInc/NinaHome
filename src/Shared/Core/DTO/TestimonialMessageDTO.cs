using System;

namespace Nina.DTO
{
    public class TestimonialMessageDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public bool Approved { get; set; } = false;
        public DateTime CreatedOnUtc { get; set; }
    }
}
