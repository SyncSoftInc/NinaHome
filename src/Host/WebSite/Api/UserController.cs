using Microsoft.AspNetCore.Mvc;
using Nina.DataAccess;
using SyncSoft.App.Components;
using System;

namespace Nina.WebSite.Api
{
    [LocalRequestOnly]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IClassScheduleMessageDAL> _lazyClassScheduleMessageDAL = ObjectContainer.LazyResolve<IClassScheduleMessageDAL>();
        private IClassScheduleMessageDAL ClassScheduleMessageDAL => _lazyClassScheduleMessageDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  IsUserAuthenticated  -

        /// <summary>
        /// User Authenticate State
        /// </summary>
        /// <returns></returns>
        [HttpGet("authstate")]
        public bool IsUserAuthenticatedAsync() => User.Identity.IsAuthenticated;

        #endregion
    }
}
