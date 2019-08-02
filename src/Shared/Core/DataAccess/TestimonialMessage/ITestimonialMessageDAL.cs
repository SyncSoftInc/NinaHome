using Nina.DTO;
using Nina.Queries;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.DataAccess.TestimonialMessage
{
    public interface ITestimonialMessageDAL
    {
        Task<string> InsertMessageAsync(TestimonialMessageDTO dto);
        Task<string> DeleteMessageAsync(Guid id);
        Task<string> ApproveMessageAsync(Guid id, bool approved);
        Task<TestimonialMessageDTO> GetMessageAsync(Guid id);
        Task<PagedList<TestimonialMessageDTO>> GetMessagesAsync(GetTestimonialMessageQuery query);
    }
}
