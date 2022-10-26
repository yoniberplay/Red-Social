using Red_Social.Infrastucture.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Red_Social.Core.Domain.Settings;
using Red_Social.Core.Application.Interfaces.Services;

namespace Red_Social.Infrastucture.Shared.Services
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddShareInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
