using Red_Social.Core.Application.ViewModels.Friendship;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Interfaces.Services
{
    public interface IFriendship : IGenericService<SaveFriendViewModel, FriendshipViewModel,Friendship>
    {
       
        
        
    }
}
