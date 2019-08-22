﻿using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Create Class Schedule Message
        /// </summary>
        /// <param name="cmd">Message Informaiton</param>
        /// <returns></returns>
        [HttpPost("message")]
        public Task<string> CreateMessageAsync(CreateClassScheduleMessageCommand cmd)
            => ClassScheduleMessageDAL.InsertMessageAsync(new ClassScheduleMessageDTO
            {
                ID = Guid.NewGuid(),
                Name = cmd.Name,
                Phone = cmd.Phone,
                Email = cmd.Email,
                Type = cmd.Type,
                Message = cmd.Message,
                CreatedOnUtc = DateTime.UtcNow
            });

        /// <summary>
        /// Delete Class Schedule Message 
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <returns></returns>
        [HttpDelete("message/{id}")]
        public Task<string> DeleteMessageAsync(Guid id) => ClassScheduleMessageDAL.DeleteMessageAsync(id);

        /// <summary>
        /// Get Class Schedule Message
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <returns></returns>
        [HttpGet("message/{id}")]
        public Task<ClassScheduleMessageDTO> GetMessageAsync(Guid id) => ClassScheduleMessageDAL.GetMessageAsync(id);

        /// <summary>
        /// Get Paged Class Schedule Message 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="pageIndex">pageIndex</param>
        /// <returns></returns>
        [HttpGet("messages")]
        public Task<PagedList<ClassScheduleMessageDTO>> GetMessagesAsync(string name, string email, int pageSize, int pageIndex)
        {
            var query = new GetClassScheduleMessageQuery
            {
                Name = name,
                Email = email,
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            return ClassScheduleMessageDAL.GetMessagesAsync(query);
        }

        #endregion
    }
}
