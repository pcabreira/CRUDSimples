using CriteriosAptas.Infrastructure.Persistence.Repositories;
using CRUDTasks.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDTasks.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITasksRepository, TasksRepository>();
            return services;
        }
    }
}
