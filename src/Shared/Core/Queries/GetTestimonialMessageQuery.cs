using SyncSoft.ECP.Queries;

namespace Nina.Queries
{
    public class GetTestimonialMessageQuery : PagedQuery
    {
        public string Name { get; set; }
        public bool? Approved { get; set; }
    }
}
