using DotNet8Mvc.NLayerArchitecture.BusinessLogic.Features.Blog;
using DotNet8Mvc.NLayerArchitecture.DataAccess.Features.Blog;
using DotNet8Mvc.NLayerArchitecture.DbService.AppDbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet8Mvc.NLayerArchitecture.Presentation
{
    public static class ModularService
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            return services.AddDbContextService(builder)
                .AddDataAccessService()
                .AddBusinessLogicService();
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            return builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient);
        }

        private static IServiceCollection AddDataAccessService(this IServiceCollection services)
        {
            return services.AddScoped<DA_Blog>();
        }

        private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
        {
            return services.AddScoped<BL_Blog>();
        }
    }
}
