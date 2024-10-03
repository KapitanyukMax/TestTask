using TestTask.Middlewares;

namespace TestTask
{
    public static class ServiceExtensions
    {
        public static void AddExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<HttpExceptionHandler>();
            services.AddProblemDetails();
        }
    }
}
