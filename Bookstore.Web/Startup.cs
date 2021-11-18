using Bookstore.EnterpriseLibrary.Constants;
using Bookstore.Web.Handlers;
using Bookstore.Web.Services;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;


namespace Bookstore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddControllersWithViews();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
           .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
           {
               options.Authority = Url.Identity_Server;
               options.ClientId = StringConstant.Books_Client_Id_Value;
               options.ClientSecret = StringConstant.Books_Client_Secret;
               options.ResponseType = StringConstant.Response_Type;

               options.Scope.Add(StringConstant.Scope_Open_Id);
               options.Scope.Add(StringConstant.Scope_Profile);
               options.Scope.Add(StringConstant.Scope_Address);
               options.Scope.Add(StringConstant.Scope_Email);
               options.Scope.Add(StringConstant.Scope_Role_Value);
               options.Scope.Add(StringConstant.Scope_Book_Api_Value);

               options.ClaimActions.MapUniqueJsonKey(StringConstant.Scope_Role_Value, StringConstant.Scope_Role_Value);

               options.SaveTokens = true;
               options.GetClaimsFromUserInfoEndpoint = true;

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   NameClaimType = JwtClaimTypes.GivenName,
                   RoleClaimType = JwtClaimTypes.Role
               };
           });
            services.AddTransient<AuthenticationHandler>();

            services.AddHttpClient(StringConstant.Http_Client_Books_Api, client =>
            {
                client.BaseAddress = new Uri(Url.Api_Gateway);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, StringConstant.Content_Type_Json);
            });
            services.AddHttpClient(StringConstant.Http_Client_Idp, client =>
            {
                client.BaseAddress = new Uri(Url.Identity_Server);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, StringConstant.Content_Type_Json);

            });
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
