using SyncSoft.App.Messaging;
using System;

namespace Nina.Commands
{
    public class CreateClassScheduleMessageCommand : RequestCommand
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Voice { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
