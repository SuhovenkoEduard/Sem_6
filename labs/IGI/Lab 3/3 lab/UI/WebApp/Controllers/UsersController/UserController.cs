using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModel;

namespace WebApp.Controllers.UsersController
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        
        [Authorize(Roles = "Admin, Moder")]
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin, Moder")]
        [HttpPost]
        public async Task<IActionResult> AddUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("AddUser", "User");
            var user = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email
            };
            var res = await _userManager.CreateAsync(user, model.Password);
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "DefaultUser");
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return RedirectToAction("Index", "User");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UserDelete(IdentityUser identityUser)
        {
            _userManager.DeleteAsync(identityUser);
            return RedirectToAction("Index", "User");
        }
        
        [Authorize(Roles = "Admin, Moder")]
        [HttpGet]
        public IActionResult UserUpdate()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Moder")]
        [HttpPost]
        public IActionResult UserUpdate(IdentityUser identityUser)
        {
            _userManager.UpdateAsync(identityUser);
            return RedirectToAction("Index", "User");
        }
    }
}