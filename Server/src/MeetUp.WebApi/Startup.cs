using FluentValidation.AspNetCore;
using MeetUp.Shared.CQRS;
using MeetUp.WebApi.Extensions;
using MeetUp.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

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

            services.AddScoped<Domain.Authentication.UserAuthenticationService>();

            services.AddScoped<Domain.Authentication.IAccessTokenFactory, Domain.Infrustructure.Authentication.JwtAccessTokenFactory>();
            services.AddScoped<Domain.Authentication.IPasswordHasher, Domain.Infrustructure.PasswordHasher.PasswordHasher>();
            services.AddScoped<Domain.Authentication.IRefreshTokenStore, Domain.Infrustructure.RefreshTokenStore.RefreshTokenStore>();
            services.AddScoped<Domain.Authentication.IUserGetter, Domain.Infrustructure.Authentication.UserGetter>();
            services.AddNpgsqlDbContextPool<Domain.Infrustructure.Authentication.AuthenticationDbContext>(npgsqlConnectionString);

            services.AddScoped<Domain.Meets.MeetCreateService>();
            services.AddScoped<Domain.Meets.IMeetRepository, Domain.Infrustructure.Meets.MeetRepository>();
            services.AddNpgsqlDbContextPool<Domain.Infrustructure.Meets.MeetDbContext>(npgsqlConnectionString);

            services.AddScoped<Domain.Registration.UserRegistrationService>();
            services.AddScoped<Domain.Registration.IUserRepository, Domain.Infrustructure.Registration.UserRepository>();
            services.AddScoped<Domain.Registration.IPasswordHasher, Domain.Infrustructure.PasswordHasher.PasswordHasher>();
            services.AddNpgsqlDbContextPool<Domain.Infrustructure.Registration.RegistrationDbContext>(npgsqlConnectionString);

            services.AddNpgsqlDbContextPool<Domain.Infrustructure.RefreshTokenStore.RefreshTokenStoreDbContext>(npgsqlConnectionString);

            services.AddQueryProcessor<Queries.Infrustructure.Samples.SampleQueryHandler>();

            services.AddNpgsqlDbContextPool<Queries.Infrustructure.Meets.MeetDbContext>(npgsqlConnectionString);


            #region DatabaseMigrations

            services.AddNpgsqlDbContext<DatabaseMigrations.MeetUpDbContext>(npgsqlConnectionString);

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
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("../v1/swagger.json", "MeetUp Api v1"); });

            app.UseRewriter(new RewriteOptions().AddRedirect(@"^$", "swagger", (int)HttpStatusCode.Redirect));

        }
    }
}
