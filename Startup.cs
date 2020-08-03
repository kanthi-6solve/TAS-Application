using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
//using TAS_AngularCoreProj.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
//using TAS_AngularCoreProj.Migrations;
using IdentityServer4.Stores;
//using IdentityServer;
using Microsoft.AspNetCore.Routing;
using DotnetCore_TAS_CandidateAPI.Models;

namespace DotnetCore_TAS_CandidateAPI
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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            // services.AddIdentity<ApplicationUser, IdentityRole>()
            //            .AddDefaultUI()
            //            .AddEntityFrameworkStores<ApplicationDbContext>()
            //                            .AddDefaultTokenProviders();

            // services.AddDbContext<ApplicationDbContext>(opt => 
            // opt.UseSqlServer(Configuration.GetConnectionString("Identityconnection")));

            services.AddDbContext<CandidateProcessDBContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("tasdbconnection")));

            //  services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //     .AddEntityFrameworkStores<ApplicationDbContext>();
            // services.AddIdentityServer()
            //     .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            // services.AddIdentity<ApplicationUser, IdentityRole>()
            // .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            // services.AddAuthentication()
            //     .AddIdentityServerJwt();
            // services.AddControllersWithViews();
            // services.AddRazorPages();

            services.AddCors(options =>
            {
                options.AddPolicy("CandCorsPolicy",
                builder => builder.WithOrigins("http://localhost:4200")
                // builder => builder.AllowAnyOrigin()
                //  builder => builder.WithOrigins("https://testangular8webapp.azurewebsites.net/")
                .AllowAnyHeader().AllowAnyMethod()
                .SetIsOriginAllowed(isOriginAllowed: _ => true));
            });

            services.AddMvc(opt => opt.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped(p => new CandidateProcessDBContext(p.GetService<DbContextOptions<CandidateProcessDBContext>>()));

            // services.AddIdentityServer().AddInMemoryCaching().AddClientStore<InMemoryClientStore>()
            // .AddResourceStore<InMemoryResourcesStore>();

            //    services.AddAuthentication();

            // services.AddTransient<IEmailSender, EmailSender>(i => 
            //     new EmailSender(
            //         Configuration["EmailSender:Host"],
            //         Configuration.GetValue<int>("EmailSender:Port"),
            //         Configuration.GetValue<bool>("EmailSender:EnableSSL"),
            //         Configuration["EmailSender:UserName"],
            //         Configuration["EmailSender:Password"]
            //     )
            // );

            // services.AddSingleton<IPersistedGrantStore, InMemoryPersistedGrantStore>();

            // services.AddIdentityServer().AddDeveloperSigningCredential()
            // .AddInMemoryClients(Config.GetClients());

            //   services.AddScoped(p => new ApplicationDbContext(p.GetService<DbContextOptions<ApplicationDbContext>>()));

            // services.Configure<ApiBehaviorOptions>(options =>
            // {
            //     options.SuppressModelStateInvalidFilter = true;
            // });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors("CandCorsPolicy");

            app.UseSession();

            // this is the request execution pipeline for client side
            app.UseMvc();

           // app.UseMvc(ConfigureRoute);
            app.UseStaticFiles();
        }
    }
}
