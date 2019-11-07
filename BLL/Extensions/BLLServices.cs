using BLL.Interfaces;
using BLL.Managers;
using BLL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extentions
{
    public static class BLLServices
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<ISnippetRepository, SnippetRepository>();
            services.AddScoped<ISnippetManager, SnippetManager>();

            return services;
        }
    }
}
