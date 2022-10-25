using Red_Social.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Friendship
{
    public class FriendshipViewModel
    {
        public int IdUser { get; set; }
        public int IdFriend { get; set; }
        public UserViewModel? User { get; set; }
    }
}
