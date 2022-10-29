using Red_Social.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red_Social.Infrastucture.Persistence.Repositories;

namespace Red_Social.Infrastructure.Persistence
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m=> m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            #endregion
        }
    }
}
