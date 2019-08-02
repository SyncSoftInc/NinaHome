using Microsoft.AspNetCore.Mvc;
using Nina.Commands;
using Nina.DataAccess.TestimonialMessage;
using Nina.DTO;
using Nina.Queries;
using SyncSoft.App.Components;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.WebSite.Api
{
#if !DEBUG
    [LocalRequestOnly]
#endif
    [Route("api/testimonial")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ITestimonialMessageDAL> _lazyTestimonialMessageDAL = ObjectContainer.LazyResolve<ITestimonialMessageDAL>();
        private ITestimonialMessageDAL TestimonialMessageDAL => _lazyTestimonialMessageDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CRUD  -

        [HttpPost("message")]
        public Task<string> CreateMessageAsync(CreateTestimonialMessageCommand cmd)
            => TestimonialMessageDAL.InsertMessageAsync(new TestimonialMessageDTO
            {
                ID = cmd.ID,
                Name = cmd.Name,
                Message = cmd.Message,
                Type = cmd.Type,
                CreatedOnUtc = DateTime.UtcNow
            });

        [HttpPatch("message")]
        public Task<string> ApproveMessageAsync(ApproveTestimonialMessageCommand cmd)
            => TestimonialMessageDAL.ApproveMessageAsync(cmd.ID, cmd.Approved);

        [HttpDelete("message/{id}")]
        public Task<string> DeleteMessageAsync(Guid id) => TestimonialMessageDAL.DeleteMessageAsync(id);

        [HttpGet("message/{id}")]
        public Task<TestimonialMessageDTO> GetMessageAsync(Guid id) => TestimonialMessageDAL.GetMessageAsync(id);

        [HttpGet("messages")]
        public Task<PagedList<TestimonialMessageDTO>> GetMessagesAsync(GetTestimonialMessageQuery query) => TestimonialMessageDAL.GetMessagesAsync(query);

        #endregion
    }
}
