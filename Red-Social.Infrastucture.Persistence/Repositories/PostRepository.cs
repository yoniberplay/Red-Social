using Microsoft.EntityFrameworkCore;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Domain.Entities;
using Red_Social.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Red_Social.Infrastructure.Persistence.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly ApplicationContext _dbContext;

        public PostRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual async Task<List<Post>> GetAllAsync()  //Se sobrescribe pero sigue cumpliendo su misma funcion SOLID
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            return await _dbContext.Set<Post>()
                .Include(a => a.User)
                .Include(c => c.Comments)
                .ToListAsync(); //Deferred execution
        }

        public virtual async Task<Post> GetBywithRelationship(int id)
        {
            var temp = await _dbContext.Set<Post>().Where(a => a.Id == id).Include(a => a.User).ToListAsync();
            return temp.First();

            //POR SI ACASO
            //  return _dbContext.Posts.Where(a => a.Id == id).Include(a => a.Fotos).Include(a => a.User).Include(a => a.Category).FirstOrDefault(); 
            //return a;
        }


    }
}
