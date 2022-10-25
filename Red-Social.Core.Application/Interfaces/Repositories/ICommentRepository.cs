using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.ViewModels.User;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Red_Social.Core.Application.Interfaces.Repositories
{

    public interface ICommentRepository : IGenericRepository<Comments>
    {

    }
}
