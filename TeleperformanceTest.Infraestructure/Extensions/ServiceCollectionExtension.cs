using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TeleperformanceTest.Core.Custom;
using TeleperformanceTest.Core.Interfaces;
using TeleperformanceTest.Core.Interfaces.Repository;
using TeleperformanceTest.Core.Interfaces.Services;
using TeleperformanceTest.Core.Services;
using TeleperformanceTest.Infrastructure.Data;
using TeleperformanceTest.Infrastructure.Interfaces;
using TeleperformanceTest.Infrastructure.Options;
using TeleperformanceTest.Infrastructure.Repositories;
using TeleperformanceTest.Infrastructure.Services;
using System;
using System.IO;
using System.Text;
using TeleperformanceTest.Infraestructure.Repositories;

namespace TeleperformanceTest.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TeleperformanceTestContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
        }

        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));
        }

        public static void AddServices(this IServiceCollection services)
        {
            //Service dependencies
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ITypeIdentificationService, IdentificationTypeService>();
            services.AddTransient<ISecurityService, SecurityService>();

            //Repository dependencies
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ITypeIdentificationRepository, IdentificationTypeRepository>();

            //Generic
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
                };
            });
        }

        public static void AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Teleperformance API", Version = "V1" });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });
        }
    }
}
