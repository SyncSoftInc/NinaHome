using Microsoft.AspNetCore.Authorization;

namespace Nina.WebSite
{
    public class LocalRequestOnlyAttribute : AuthorizeAttribute
    {
        public const string PolicyName = "LocalRequestOnly";

        public LocalRequestOnlyAttribute() : base(PolicyName)
        {

        }
    }
}
