using SyncSoft.App.Messaging;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nina.Commands
{
    public class CreateContactMessageCommand : RequestCommand
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
