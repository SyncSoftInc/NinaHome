using SyncSoft.App.Messaging;
using System;

namespace Nina.Commands
{
    public class CreateTestimonialMessageCommand : RequestCommand
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public bool Approved { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
