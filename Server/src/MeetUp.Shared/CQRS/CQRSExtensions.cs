using Microsoft.Extensions.DependencyInjection;

namespace MeetUp.Shared.CQRS
{
    public static class CQRSExtensions
    {
        /// <summary>
        /// Add CQRS query processor
        /// </summary>
        /// <typeparam name="H">Handler from assembly to register all available handlers in assembly</typeparam>
        public static void AddQueryProcessor<H>(this IServiceCollection services) where H : IQueryHandler
        {
            var queryHandlerRegistry = new QueryHandlerRegistry();
            queryHandlerRegistry.AddQueryHandlers<H>();

            services.AddSingleton<IQueryHandlerRegistry>(queryHandlerRegistry);

            foreach (var handler in queryHandlerRegistry.Handlers)
            {
                services.AddScoped(handler);
            }
            services.AddScoped<IQueryProcessor, QueryProcessor>();
        }
    }
}
