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
            
            services.AddMvc();

            SpreadsheetGear.Factory.SetSignedLicense("SpreadsheetGear.License, Type=Standard, Hash=WioEMdfC8fMSQEtq1vYoYCc, Product=NST, NewVersionsUntil=2018-09-21, Company=Inercya , Email=alberto.benito@i-nercya.com, Signature=jvCldFJmXfqVtvvRIxFawfQi6w/fldeOPFKu8O+59wA'-#ZXSVQYJucLxsS0czyA8cZ66+uy4Q9NvNUyP2bFDPvf4A#J");



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
