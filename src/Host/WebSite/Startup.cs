using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using SyncSoft.App.Components;
using SyncSoft.App.Configurations;
using SyncSoft.ECP.AspNetCore.Hosting;
using System;
using System.IO;

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
            //services.AddMvcCore()
            //    .AddApiExplorer();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Nina Home API", Version = "v1" });

                c.SchemaFilter<SwaggerExcludeFilter>();

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Nina.WebSite.xml");
                c.IncludeXmlComments(filePath);
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseReverseProxy();

            app.UseCors("MyPolicy");

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }

    public class SwaggerExcludeFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
                return;

            schema.Properties.Remove("correlationId");
            schema.Properties.Remove("claims");
        }
    }
}
