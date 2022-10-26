using Microsoft.EntityFrameworkCore;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.ViewModels.User;
using Red_Social.Core.Domain.Entities;
using Red_Social.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;

namespace Red_Social.Infrastructure.Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<User> AddAsync(User entity)
        {
            entity.Password = PasswordEncryptation.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<User> GetByUsernameAsync(string? username)
        {
            var temp = await _dbContext.Set<User>().Where(u => u.Username == username).ToListAsync();
            return temp.First();
        }

        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypt = PasswordEncryptation.ComputeSha256Hash(loginVm.Password);
            User user = await _dbContext.Set<User>().FirstOrDefaultAsync(user=> user.Username == loginVm.Username && user.Password == passwordEncrypt);
            return user;
        }

    }
}
