using AG.Utilities;
using AG.Data;
using AG.SeedData;
using AG.Service;
using AG.Service.Interface;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Text;

namespace AG.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aerial Golf"));

            app.UseAuthentication();            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = AddConfig(services);
            AddAuth(services);
            AddMvc(services);               

            if (!_env.IsEnvironment("Test"))
            {
                AddAgServices(services, config);               
            }

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info()));
        }

        private void AddAgServices(IServiceCollection services, IConfigurationRoot config)
        {
            var options = new DbContextOptionsBuilder<AgContext>()
                                        .UseSqlServer(config.GetConnectionString("GolfConn"))
                                        .Options;

            new AgContext(options).Database.Migrate();

            services.AddTransient(s => new AsyncFactory<AgContext>(() => new AgContext(options)));

            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseInfoService, CourseInfoService>();
            services.AddTransient<IHoleService, HoleService>();
        }

        private void AddMvc(IServiceCollection services)
        {
            services.AddMvc()
                    .AddFluentValidation(v =>
                    {
                        v.RegisterValidatorsFromAssemblyContaining<Startup>();
                        v.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    })
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    });
        }

        private void AddAuth(IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddUserStore<MyUserStore>()
                .AddRoleStore<MyRoleStore>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("Dealer", policy =>
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.RequireAssertion(c => c.User.IsDealer());
                //});
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "yourdomain.com",
                            ValidAudience = "yourdomain.com",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("keygoesherekeygoeshere"))
                        };
                    })
                    .AddCookie();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, ClaimsPrincipalFactory>();
        }

        private IConfigurationRoot AddConfig(IServiceCollection services)
        {
            string appSettings;
            if (_env.IsEnvironment("Test"))
            {
                appSettings = "Config/appsettings.test.json";
            }
            else if (_env.IsDevelopment())
            {
                appSettings = "Config/appsettings.development.json";
            }
            else if (_env.IsProduction())
            {
                appSettings = "Config/appsettings.production.json";
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{_env.EnvironmentName} is not a valid environment");
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appSettings)
                .Build();

            services.AddSingleton(config);

            return config;
        }
    }
}
