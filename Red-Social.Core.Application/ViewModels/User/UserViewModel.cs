﻿using Red_Social.Core.Application.ViewModels.Friendship;
using Red_Social.Core.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
 
        public string Phone { get; set; }

        public ICollection<PostViewModel> Post { get; set; }
        public ICollection<FriendshipViewModel>? Friendship { get; set; }
    }
}
