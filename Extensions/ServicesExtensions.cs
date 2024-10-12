using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Ocorpus.AuthorizationService.Middlewares;
using OCorpus.AuthorizationService.Contexts;
using OCorpus.AuthorizationService.Repositories;
using OCorpus.AuthorizationService.Repositories.Interfaces;
using OCorpus.AuthorizationService.Services;
using OCorpus.AuthorizationService.Services.Interfaces;

namespace OCorpus.AuthorizationService.Extensions;

/// <summary>
///     Extension class for IServiceCollection
/// </summary>
public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        // mapper
        services.AddAutoMapper(typeof(Program));

        // db related
        services.AddScoped<OCorpusDbContext>();

        //middlewares
        services.AddScoped<ExceptionHandlingMiddleware>();

        // other services
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("OCorpusDb");

        services.AddDbContext<OCorpusDbContext>(options =>
            options.UseSqlServer(connectionString)
        );
    }

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "OCorpus API", Version = "v1" });
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "OCorpus.AuthorizationService.xml"));
        });
    }
}