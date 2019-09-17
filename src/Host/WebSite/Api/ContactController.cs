using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nina.Commands;
using Nina.Components;
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

        private static readonly Lazy<IEmailSender> _lazyEmailSender = ObjectContainer.LazyResolve<IEmailSender>();
        private IEmailSender EmailSender => _lazyEmailSender.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CRUD  -

        /// <summary>
        /// Create Contact Message
        /// </summary>
        /// <param name="cmd">Message Information</param>
        /// <returns></returns>
        [HttpPost("message")]
        public async Task<string> CreateMessageAsync(CreateContactMessageCommand cmd)
        {
            var dto = new ContactMessageDTO
            {
                ID = Guid.NewGuid(),
                Name = cmd.Name,
                Phone = cmd.Phone,
                Email = cmd.Email,
                Message = cmd.Message,
                CreatedOnUtc = DateTime.UtcNow
            };

            var msgCode = await ContactMessageDAL.InsertMessageAsync(dto).ConfigureAwait(false);
            if (msgCode.IsSuccess())
            {
                var subject = $"[mylightangel.com]: Contact message from {dto.Email}";
                var body = $"<p>Name: {dto.Name}</p><p>Phone: {dto.Phone}</p><p>Email: {dto.Email}</p><p>Message: {dto.Message}</p>";

                msgCode = await EmailSender.SendAsync(subject, body).ConfigureAwait(false);
            }

            return msgCode;
        }

        /// <summary>
        /// Delete Contact Message
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <returns></returns>
        [HttpDelete("message/{id}")]
        [Authorize]
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
