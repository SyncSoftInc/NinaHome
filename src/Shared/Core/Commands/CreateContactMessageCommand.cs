using SyncSoft.App.Messaging;
using System;

namespace Nina.Commands
{
    public class CreateContactMessageCommand : RequestCommand
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
