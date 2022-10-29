using Red_Social.Core.Application.ViewModels.Comments;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Interfaces.Services
{
    public interface ICommentService : IGenericService<SaveCommentViewModel, CommentsViewModel,Comments>
    {
      
    }
}
