﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IFriendship _friendservice;
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _ihttpContextAccessor;
        private readonly UserViewModel? userViewModel;


        public AmigosController(ILogger<HomeController> logger, ValidateUserSession validateUserSession, ICommentService commentService, IUserService userService, IHttpContextAccessor ihttpContextAccessor, IFriendship friendservice)
        {
            _validateUserSession = validateUserSession;
            _userService = userService;
            _logger = logger;
            _ihttpContextAccessor = ihttpContextAccessor;
            _friendservice = friendservice;
            _commentService = commentService;
            userViewModel = _ihttpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<IActionResult> Index()
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.user = userViewModel;
            ViewBag.friendpost = await _friendservice.GetAllViewModel();

            return View();
        }

        public async Task<IActionResult> agregar()
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> agregar(SaveFriendViewModel sfvm)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "User", action = "agregar" });
            }


            return View();
        }


    }
    }

    

