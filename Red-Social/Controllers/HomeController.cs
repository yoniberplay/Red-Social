using Microsoft.AspNetCore.Mvc;
using Red_Social.Middlewares;
using Red_Social.Models;
using System.Diagnostics;
using Red_Social.Core.Application.ViewModels.Post;
using Red_Social.Core.Application.ViewModels.User;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.ViewModels.Comments;

namespace Red_Social.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUserSession _validateUserSession;
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _ihttpContextAccessor;
        private readonly UserViewModel? userViewModel;

        public HomeController(ILogger<HomeController> logger, ValidateUserSession validateUserSession, ICommentService commentService ,IUserService userService, IHttpContextAccessor ihttpContextAccessor, IPostService postService)
        {
            _validateUserSession = validateUserSession;
            _userService = userService;
            _logger = logger;
            _ihttpContextAccessor = ihttpContextAccessor;
            _postService = postService;
            _commentService = commentService;
            userViewModel = _ihttpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public  async Task<IActionResult> Index()
        {
            
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "nopermiso" });
            }

            ViewBag.user = userViewModel;
            ViewBag.UserPost = await _postService.GetAllMyPost();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreatePost(SavePostViewModel spvm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "nopermiso" });
            }
            if (spvm.File != null )
            {
                spvm.ImgUrl = AdmFiles.UploadFile(spvm.File, userViewModel.Id, "Posts");
            }

            

            await _postService.Add(spvm);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(SavePostViewModel spvm)
        {
           
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "nopermiso" });
            }

            if (spvm.NuevoComentario == null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

           SaveCommentViewModel savecomment = new();
            savecomment.Text = spvm.NuevoComentario;
            savecomment.PostId = spvm.Idpost;
            savecomment.UserId = userViewModel.Id;


            await _commentService.Add(savecomment);




            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult nopermiso()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}