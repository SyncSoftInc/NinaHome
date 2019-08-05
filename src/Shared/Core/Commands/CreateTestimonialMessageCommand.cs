using SyncSoft.App.Messaging;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nina.Commands
{
    public class CreateTestimonialMessageCommand : RequestCommand
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public bool Approved { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
