using Nina.DTO;
using SyncSoft.App.Http;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.Api.ContactMessage
{
    public interface IContactMessageApi
    {
        Task<HttpResult<string>> CreateMessageAsync(object cmd);
        Task<HttpResult<string>> DeleteMessageAsync(Guid id);
        Task<HttpResult<ContactMessageDTO>> GetMessageAsync(Guid id);
        Task<HttpResult<PagedList<ContactMessageDTO>>> GetMessagesAsync(object query);
    }
}