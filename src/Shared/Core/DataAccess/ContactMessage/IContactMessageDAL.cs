using Nina.DTO;
using Nina.Queries;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.DataAccess
{
    public interface IContactMessageDAL
    {
        Task<string> InsertMessageAsync(ContactMessageDTO dto);
        Task<string> DeleteMessageAsync(Guid id);
        Task<ContactMessageDTO> GetMessageAsync(Guid id);
        Task<PagedList<ContactMessageDTO>> GetMessagesAsync(GetContactMessageQuery query);
    }
}
