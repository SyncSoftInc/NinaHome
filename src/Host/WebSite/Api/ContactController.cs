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
    [LocalRequestOnly]
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

        /// <summary>
        /// Create Contact Message
        /// </summary>
        /// <param name="cmd">Message Information</param>
        /// <returns></returns>
        [HttpPost("message")]
        public Task<string> CreateMessageAsync(CreateContactMessageCommand cmd)
            => ContactMessageDAL.InsertMessageAsync(new ContactMessageDTO
            {
                ID = Guid.NewGuid(),
                Name = cmd.Name,
                Phone = cmd.Phone,
                Email = cmd.Email,
                Message = cmd.Message,
                CreatedOnUtc = DateTime.UtcNow
            });

        /// <summary>
        /// Delete Contact Message
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <returns></returns>
        [HttpDelete("message/{id}")]
        public Task<string> DeleteMessageAsync(Guid id) => ContactMessageDAL.DeleteMessageAsync(id);

        /// <summary>
        /// Get Contact Message
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <returns></returns>
        [HttpGet("message/{id}")]
        public Task<ContactMessageDTO> GetMessageAsync(Guid id) => ContactMessageDAL.GetMessageAsync(id);

        /// <summary>
        /// Get Paged Contact Message
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="pageIndex">pageIndex</param>
        /// <returns></returns>
        [HttpGet("messages")]
        public Task<PagedList<ContactMessageDTO>> GetMessagesAsync(string name, string email, int pageSize, int pageIndex)
        {
            var query = new GetContactMessageQuery
            {
                Name = name,
                Email = email,
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            return ContactMessageDAL.GetMessagesAsync(query);
        }

        #endregion
    }
}
