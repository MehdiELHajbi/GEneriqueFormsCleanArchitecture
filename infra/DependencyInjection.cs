using Application.Contracts.Infrastructure;
using infra.FileExport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<ICsvExporter, CsvExporter>();
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }

}
