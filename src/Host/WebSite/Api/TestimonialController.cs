﻿using Microsoft.AspNetCore.Authorization;
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
    [LocalRequestOnly]
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

        /// <summary>
        /// Create Testimonial Message
        /// </summary>
        /// <param name="cmd">Message Information</param>
        /// <returns></returns>
        [HttpPost("message")]
        public Task<string> CreateMessageAsync(CreateTestimonialMessageCommand cmd)
            => TestimonialMessageDAL.InsertMessageAsync(new TestimonialMessageDTO
            {
                ID = Guid.NewGuid(),
                Name = cmd.Name,
                Message = cmd.Message,
                Type = cmd.Type,
                CreatedOnUtc = DateTime.UtcNow
            });

        /// <summary>
        /// Approve Testimonial Message
        /// </summary>
        /// <param name="cmd">Approve command information</param>
        /// <returns></returns>
        [HttpPatch("message")]
        [Authorize]
        public Task<string> ApproveMessageAsync(ApproveTestimonialMessageCommand cmd)
            => TestimonialMessageDAL.ApproveMessageAsync(cmd.ID, cmd.Approved);

        /// <summary>
        /// Delete Testimonial Message
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("message/{id}")]
        public Task<string> DeleteMessageAsync(Guid id) => TestimonialMessageDAL.DeleteMessageAsync(id);

        /// <summary>
        /// Get Testimonial Message
        /// </summary>
        /// <param name="id">Message ID</param>
        /// <returns></returns>
        [HttpGet("message/{id}")]
        public Task<TestimonialMessageDTO> GetMessageAsync(Guid id) => TestimonialMessageDAL.GetMessageAsync(id);

        /// <summary>
        /// Get Paged Testimonial Message
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="approved">approved</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="pageIndex">pageIndex</param>
        /// <returns></returns>
        [HttpGet("messages")]
        public Task<PagedList<TestimonialMessageDTO>> GetMessagesAsync(string name, bool? approved, int pageSize, int pageIndex)
        {
            //bool? approved;
            //if (User.Identity.IsAuthenticated)
            //{
            //    approved = null;
            //}
            //else
            //{
            //    approved = true;
            //}

            var query = new GetTestimonialMessageQuery
            {
                Name = name,
                Approved = approved,
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            return TestimonialMessageDAL.GetMessagesAsync(query);
        }

        #endregion
    }
}
