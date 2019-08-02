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
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IClassScheduleMessageDAL> _lazyClassScheduleMessageDAL = ObjectContainer.LazyResolve<IClassScheduleMessageDAL>();
        private IClassScheduleMessageDAL ClassScheduleMessageDAL => _lazyClassScheduleMessageDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CRUD  -

        [HttpPost("message")]
        public Task<string> CreateMessageAsync(CreateClassScheduleMessageCommand cmd)
            => ClassScheduleMessageDAL.InsertMessageAsync(new ClassScheduleMessageDTO
            {
                ID = cmd.ID,
                Name = cmd.Name,
                Voice = cmd.Voice,
                Email = cmd.Email,
                Class = cmd.Class,
                Message = cmd.Message,
                CreatedOnUtc = DateTime.UtcNow
            });

        [HttpDelete("message/{id}")]
        public Task<string> DeleteMessageAsync(Guid id) => ClassScheduleMessageDAL.DeleteMessageAsync(id);

        [HttpGet("message/{id}")]
        public Task<ClassScheduleMessageDTO> GetMessageAsync(Guid id) => ClassScheduleMessageDAL.GetMessageAsync(id);

        [HttpGet("messages")]
        public Task<PagedList<ClassScheduleMessageDTO>> GetMessagesAsync(GetClassScheduleMessageQuery query)
            => ClassScheduleMessageDAL.GetMessagesAsync(query);

        #endregion
    }
}
