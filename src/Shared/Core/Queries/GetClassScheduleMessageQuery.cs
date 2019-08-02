using SyncSoft.ECP.Queries;

namespace Nina.Queries
{
    public class GetClassScheduleMessageQuery : PagedQuery
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
