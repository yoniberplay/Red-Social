using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Domain.Entities;
using Red_Social.Infrastructure.Persistence.Contexts;
using Red_Social.Infrastructure.Persistence.Repository;

namespace Red_Social.Infrastucture.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comments>, ICommentRepository
    {
        public CommentRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
