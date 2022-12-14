using Red_Social.Core.Application.ViewModels.Comments;
using Red_Social.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public String? Text { get; set; }
        public String? ImgUrl { get; set; }

        public DateTime? Created { get; set; }

        public ICollection<CommentsViewModel>? Comments { get; set; }

        public UserViewModel? User { get; set; }


    }
}
