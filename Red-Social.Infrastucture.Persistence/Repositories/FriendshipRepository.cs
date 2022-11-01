using Red_Social.Infrastructure.Persistence.Repository;
using System;
using Red_Social.Core.Application.Interfaces.Repositories;
using System.Collections.Generic;
using Red_Social.Core.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red_Social.Infrastructure.Persistence.Contexts;

namespace Red_Social.Infrastucture.Persistence.Repositories
{
    public class FriendshipRepository : GenericRepository<Friendship>, IFriendshipRepository
    {
        private readonly ApplicationContext _dbContext;

        public FriendshipRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Friendship>> GetBywithRelationship(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
