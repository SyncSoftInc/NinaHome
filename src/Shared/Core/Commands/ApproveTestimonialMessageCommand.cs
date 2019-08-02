using SyncSoft.App.Messaging;
using System;

namespace Nina.Commands
{
    public class ApproveTestimonialMessageCommand : RequestCommand
    {
        public Guid ID { get; set; }
        public bool Approved { get; set; }
    }
}
