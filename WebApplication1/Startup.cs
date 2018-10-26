using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Entities;
using WebApplication1.Helpers;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Services;

using AutoMapper;

namespace WebApplication1
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

            /*
            Because EF Core will automatically fix-up navigation properties, you can end up with cycles in your object graph. For example, Loading a blog and it's related posts will result in a blog object that references a collection of posts. Each of those posts will have a reference back to the blog.
            Some serialization frameworks do not allow such cycles. For example, Json.NET will throw the following exception if a cycle is encoutered.
            Newtonsoft.Json.JsonSerializationException: Self referencing loop detected for property 'Blog' with type 'MyApplication.Models.Blog'.
            If you are using ASP.NET Core, you can configure Json.NET to ignore cycles that it finds in the object graph. This is done in the ConfigureServices(...) method in Startup.cs.
            */


            services.AddMvc()
              .AddJsonOptions(
               options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            ;


            SpreadsheetGear.Factory.SetSignedLicense("******");



            // Esto es para añadir el EntityLite
            //serviceRegistry.Register<IContractManagementDataServiceFactory, ContractManagementDataServiceFactory>(new PerContainerLifetime());
            string ConnectionString = Configuration.GetConnectionString("ContractManagement");
            ContractManagementDataService contractManagementDataService = new ContractManagementDataService(ConnectionString, "System.Data.SqlClient");
            
            services.AddSingleton<ContractManagementDataService>(contractManagementDataService);


            // para mapear user to userdto
            services.AddAutoMapper();
           // services.AddAutoMapper(typeof(Startup));


            //Esto es para la autentificacion
            services.AddCors();


            // añadiendo dbcontext al DI
            //services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("TestDb"));

            var connection = @"Server=localhost\SQLEXPRESS;Database=ContosoUniversity;Trusted_Connection=True;";
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));


            // configure strongly typed settings objects

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);



            // configure jwt authentication

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>

            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {       



            // global cors policy

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseAuthentication();



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
