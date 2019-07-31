using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using SyncSoft.App.Components;
using SyncSoft.App.Configurations;
using SyncSoft.ECP.AspNetCore.Hosting;
using System;

namespace Nina.WebSite
{
    public class Startup : SerilogStartup
    {
        private static readonly Lazy<IConfigProvider> _lazyConfigProvider = ObjectContainer.LazyResolve<IConfigProvider>();
        private IConfigProvider ConfigProvider => _lazyConfigProvider.Value;

        public void ConfigureServices(IServiceCollection services)
        {
            var localRequestOnly = ConfigProvider.GetValue<bool>("Security:LocalRequestOnly");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthorization(a =>
            {
                a.AddPolicy(LocalRequestOnlyAttribute.PolicyName, b =>
                {
                    b.RequireAssertion(context =>
                    {
                        if (!localRequestOnly) return true;
                        // ^^^^^^^^^^

                        if (context.Resource is AuthorizationFilterContext mvcContext)
                        {
                            return mvcContext.HttpContext.Request.IsLocal();
                        }
                        return false;
                    });
                });
            });

            services.AddWebSiteServer(o =>
            {
                o.AuthenticationSchemes = new[] { CookieAuthenticationDefaults.AuthenticationScheme };
                o.ConfigAuthenticationOptions = a => a.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseReverseProxy();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseFileServer();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}
