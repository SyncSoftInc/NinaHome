using Nina.DTO;
using SyncSoft.App.Http;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.Api.ContactMessage
{
    public interface IClassScheduleMessageApi
    {
        Task<HttpResult<string>> CreateMessageAsync(object cmd);
        Task<HttpResult<string>> DeleteMessageAsync(Guid id);
        Task<HttpResult<ClassScheduleMessageDTO>> GetMessageAsync(Guid id);
        Task<HttpResult<PagedList<ClassScheduleMessageDTO>>> GetMessagesAsync(string name = null, string email = null);
    }
}