using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Red_Social.Core.Application.ViewModels.Post
{
    public class SavePostViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "La publicacion no puede estar vacia.")]
        [DataType(DataType.Text)]
        public String? Text { get; set; }
        public String? ImgUrl { get; set; }
        public IFormFile? File { get; set; }

    }
}
