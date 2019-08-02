using Microsoft.AspNetCore.Mvc;
using Nina.Commands;
using Nina.DataAccess;
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
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IContactMessageDAL> _lazyContactMessageDAL = ObjectContainer.LazyResolve<IContactMessageDAL>();
        private IContactMessageDAL ContactMessageDAL => _lazyContactMessageDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CRUD  -

        [HttpPost("message")]
        public Task<string> CreateMessageAsync(CreateContactMessageCommand cmd)
            => ContactMessageDAL.InsertMessageAsync(new ContactMessageDTO
            {
                ID = cmd.ID,
                Name = cmd.Name,
                Phone = cmd.Phone,
                Email = cmd.Email,
                Message = cmd.Message,
                CreatedOnUtc = DateTime.UtcNow
            });

        [HttpDelete("message/{id}")]
        public Task<string> DeleteMessageAsync(Guid id) => ContactMessageDAL.DeleteMessageAsync(id);

        [HttpGet("message/{id}")]
        public Task<ContactMessageDTO> GetMessageAsync(Guid id) => ContactMessageDAL.GetMessageAsync(id);

        [HttpGet("messages")]
        public Task<PagedList<ContactMessageDTO>> GetMessagesAsync(GetContactMessageQuery query) => ContactMessageDAL.GetMessagesAsync(query);

        #endregion
    }
}
