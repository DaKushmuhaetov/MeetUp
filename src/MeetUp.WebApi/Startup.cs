using FluentValidation.AspNetCore;
using MeetUp.WebApi.Extensions;
using MeetUp.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeetUp.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var npgsqlConnectionString = Configuration.GetConnectionString("MeetUp");

            services
                .AddControllers(options =>
                {
                    options.EnableEndpointRouting = false;
                })
                .AddFluentValidation(configuration =>
                {
                    configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
                    configuration.LocalizationEnabled = false;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddSwagger();


            services.AddHealthChecks()
                .AddNpgSql(npgsqlConnectionString);

            #region Authentication and Authorization

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Auth:UserJwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Auth:UserJwt:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Auth:UserJwt:SecretKey"])),
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddAuthorization(options =>
            {
                var userPolicy = new AuthorizationPolicyBuilder("user").RequireAuthenticatedUser();
                options.AddPolicy("user", userPolicy.Build());
            });
            #endregion
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAspNetCorePathBase();

            app.UseRequestResponseLogging();

            app.UseDbConcurrencyExceptionHandling();

            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger("{documentName}/swagger.json");
                endpoints.MapHealthChecks("hc");
            });

            app.UseSwagger(options => { options.RouteTemplate = "{documentName}/swagger.json"; });
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("../v1/swagger.json", "Boxis Api v1"); });

            app.UseRewriter(new RewriteOptions().AddRedirect(@"^$", "swagger", (int)HttpStatusCode.Redirect));

        }
    }
}
