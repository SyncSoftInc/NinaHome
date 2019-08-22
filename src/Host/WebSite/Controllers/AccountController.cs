using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nina.DTO;
using Nina.WebSite.Model;
using SyncSoft.App.Components;
using SyncSoft.App.Configurations;
using SyncSoft.ECP.Securities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nina.WebSite.Controllers
{
    public class AccountController : Controller
    {
        private static readonly Lazy<IConfigProvider> _lazyConfigProvider = ObjectContainer.LazyResolve<IConfigProvider>();
        private IConfigProvider ConfigProvider => _lazyConfigProvider.Value;

        private static readonly Lazy<IPasswordEncryptor> _lazyPasswordEncryptor = ObjectContainer.LazyResolve<IPasswordEncryptor>();
        private IPasswordEncryptor PasswordEncryptor => _lazyPasswordEncryptor.Value;

#if DEBUG
        [Authorize]
        public IActionResult Test()
        {
            return View();
        }
#endif

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountModel model)
        {
            //var salt = PasswordEncryptor.GeneratePasswordSalt();
            //var password = PasswordEncryptor.HashEncodePassword("Famous901", salt);
            //return View();

            if (!ModelState.IsValid) return View(model);
            // ^^^^^^^^^^

            var users = ConfigProvider.GetListValue<UserDTO>("Users");

            // check username
            var user = users.FirstOrDefault(x => x.Username == model.Username);
            if (user.IsNull())
            {
                ModelState.AddModelError("Error", "Incorrect username!");
                return View(model);
            }
            // ^^^^^^^^^^

            // check password
            var password = PasswordEncryptor.HashEncodePassword(model.Password, user.PasswordSalt);
            if (user.Password == password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = model.RememberMe,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Redirect("~/");
            }
            else
            {
                ModelState.AddModelError("Error", "Incorrect password!");
                return View(model);
            }
        }
    }
}