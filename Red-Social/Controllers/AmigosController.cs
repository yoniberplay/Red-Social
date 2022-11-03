using Microsoft.AspNetCore.Mvc;
using Red_Social.Middlewares;
using Red_Social.Models;
using System.Diagnostics;
using Red_Social.Core.Application.ViewModels.Post;
using Red_Social.Core.Application.ViewModels.User;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.ViewModels.Comments;
using Red_Social.Core.Application.ViewModels.Friendship;

namespace Red_Social.Controllers
{
    public class AmigosController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUserSession _validateUserSession;
        private readonly IUserService _userService;
        private readonly IFriendshipService _friendservice;
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _ihttpContextAccessor;
        private readonly UserViewModel? userViewModel;
        private readonly IPostService _postService;


        public AmigosController(ILogger<HomeController> logger, IPostService postService, ValidateUserSession validateUserSession, ICommentService commentService, IUserService userService, IHttpContextAccessor ihttpContextAccessor, IFriendshipService friendservice)
        {
            _validateUserSession = validateUserSession;
            _userService = userService;
            _logger = logger;
            _ihttpContextAccessor = ihttpContextAccessor;
            _friendservice = friendservice;
            _commentService = commentService;
            _postService = postService;
            userViewModel = _ihttpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<IActionResult> Index()
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "nopermiso" });
            }

            ViewBag.user = userViewModel;
            
            var tempfriend = await _friendservice.GetAllFriends();

            if (tempfriend.Count() > 0)
            {

                var postViews = await _postService.GetAllMyFriendPost(tempfriend.First().IdFriend);

            
                for (int i = 1; i < tempfriend.Count(); i++)
                {
                    var temp = await _postService.GetAllMyFriendPost(tempfriend[i].IdFriend);
                    postViews.AddRange(temp.ToList());
                }
                HashSet<string> nombres = new HashSet<string>();

                foreach (var i in postViews)
                {
                    nombres.Add(i.User.Name);

                }

                ViewBag.amigos = nombres.ToList();
                ViewBag.friendpost = postViews;
            }
            return View();
        }

        public async Task<IActionResult> agregaramigo()
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "nopermiso" });
            }

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> agregar(SaveFriendViewModel sfvm)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "nopermiso" });
            }
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "User", action = "agregar" });

            }
            UserViewModel existe  = await _userService.GetByusernameViewModel(sfvm.amigo);

            if (existe == null)
            {
                return View("agregaramigo", null);
            }

            sfvm.IdFriend = existe.Id;
            sfvm.IdUser = userViewModel.Id;
            await _friendservice.Add(sfvm);

            int temp = sfvm.IdFriend;
            sfvm.IdFriend = sfvm.IdUser;
            sfvm.IdUser = temp;
            await _friendservice.Add(sfvm);


            return View("Index", null);

        }




    }
    }

    

