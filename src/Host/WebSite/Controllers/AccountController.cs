using Microsoft.AspNetCore.Mvc;

namespace Nina.WebSite.Controllers
{
    public class AccountController : Controller
    {
        //[Authorize]
        //public IActionResult Test()
        //{
        //    return Content("Test");
        //}

        public IActionResult Login()
        {
            return View();
        }
    }
}