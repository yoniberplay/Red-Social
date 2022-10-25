using Microsoft.AspNetCore.Mvc;
using Red_Social.Core.Application.ViewModels.User;
using System.Threading.Tasks;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Middlewares;

namespace Red_Social.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUserSession;

        public UserController(IUserService userService, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            UserViewModel userVm = await _userService.Login(vm);
            if (userVm != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userVm);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso incorrecto");
            }

            return View(vm);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public IActionResult Register()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(new SaveUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            try
            {   
                SaveUserViewModel SU = await _userService.Add(vm);

                if (SU.Id != 0 && SU != null)
                {
                    SU.Photo = AdmFiles.UploadFile(vm.File, SU.Id,"Users");
                    await _userService.Update(SU);

                }
                }
            catch
            {
                ModelState.AddModelError("Username", "Este nombre de usuario esta en uso.");
                return View(vm);
            }



            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public IActionResult Forgot()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(new ForgotPassViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Forgot(ForgotPassViewModel fm)
        {
            if (!ModelState.IsValid)
            {
                return View(fm);
            }
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            try
            {

                //ENVIO DE CORREO AL USUARIO CON CLAVE NUEVA
                // await _userService.Add(fm);
            }
            catch
            {
                ModelState.AddModelError("Username", "El usuario no existe.");
                return View(fm);
            }



            return RedirectToRoute(new { controller = "User", action = "Index" });

        }
    }
}
