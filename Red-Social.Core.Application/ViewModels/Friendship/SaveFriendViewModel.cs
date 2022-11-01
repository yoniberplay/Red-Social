using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Friendship
{
    public class SaveFriendViewModel
    {

        [Required(ErrorMessage = "No puede esta vacio")]
        [DataType(DataType.Text)]
        public string amigo { get; set; }

    }
}
