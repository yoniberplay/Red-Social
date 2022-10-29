using Red_Social.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.Interfaces.Services;
using System.Reflection;

namespace Red_Social.Core.Application
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services,IConfiguration configuration)
        {
            #region Services
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
