using AsignmentEcomerce.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AsignmentEcomerce.IdentityServer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsignmentEcomerce.Models;
using AsignmentEcomerce.Services;
using AsignmentEcomerce.Services.Repositories;

namespace AsignmentEcomerce
{
    public class Startup
    {
        public static Dictionary<string, string> clientUrls;
       public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

   /*     public static Dictionary<string, string> clientUrls;*/

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             clientUrls = new Dictionary<string, string>
            {
                ["Mvc"] = Configuration["ClientUrl:Mvc"],
                ["Swagger"] = Configuration["ClientUrl:Swagger"],
                ["React"] = Configuration["ClientUrl:React"]
            };
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
           

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
               .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
               .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
              .AddInMemoryClients(IdentityServerConfig.Clients(clientUrls))
              .AddAspNetIdentity<IdentityUser>()
              .AddProfileService<CustomProfileService>()
               .AddDeveloperSigningCredential(); // not recommended for production - you need to store your key material 

            services.AddAuthentication()
               .AddLocalApi("Bearer", option =>
               {
                   option.ExpectedScope = "rookieshop.api";
               });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                }); 
                

            });
          /*  services.AddCorsOrigins(Configuration);*/

            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<IRateRepository, RateRepository>();
            services.AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddControllersWithViews()

                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                  
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rookie Shop API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("/connect/token", UriKind.Relative),
                            AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
                            Scopes = new Dictionary<string, string> { { "rookieshop.api", "Rookie Shop API" } }
                        },
                    },
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>{ "rookieshop.api" }
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseCors(o=> {
                o.AllowAnyMethod();
                o.AllowAnyHeader();
                o.AllowAnyOrigin();
             
            });
            /*app.UseCors(AllowOrigins.OriginPolicy);*/
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("swagger");
                c.OAuthClientSecret("secret");
                c.OAuthUsePkce();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecomerce API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
