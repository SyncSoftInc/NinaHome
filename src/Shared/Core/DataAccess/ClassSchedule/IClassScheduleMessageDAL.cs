using Nina.DTO;
using Nina.Queries;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.DataAccess
{
    public interface IClassScheduleMessageDAL
    {
        Task<string> InsertMessageAsync(ClassScheduleMessageDTO dto);
        Task<string> DeleteMessageAsync(Guid id);
        Task<ClassScheduleMessageDTO> GetMessageAsync(Guid id);
        Task<PagedList<ClassScheduleMessageDTO>> GetMessagesAsync(GetClassScheduleMessageQuery query);
    }
}
