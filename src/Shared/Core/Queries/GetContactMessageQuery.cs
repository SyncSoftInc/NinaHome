using SyncSoft.ECP.Queries;

namespace Nina.Queries
{
    public class GetContactMessageQuery : PagedQuery
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
