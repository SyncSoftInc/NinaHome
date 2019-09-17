using Microsoft.AspNetCore.Mvc;

namespace Nina.WebSite.Api
{
    [LocalRequestOnly]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // *******************************************************************************************************************************
        #region -  IsUserAuthenticated  -

        /// <summary>
        /// Get user authentication state
        /// </summary>
        [HttpGet("authentication")]
        public bool IsUserAuthenticatedAsync() => User.Identity.IsAuthenticated;

        #endregion
    }
}
