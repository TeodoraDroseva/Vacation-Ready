using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vacation_Ready.Models;
using Vacation_Ready.Models.Users;

namespace Vacation_Ready.Controllers
{
    public class HomeController : Controller
    {
        private readonly VacationReadyContext _context;
        private readonly UserManager<UsersModel> userManager;
        private readonly SignInManager<UsersModel> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public HomeController(VacationReadyContext context, UserManager<UsersModel> userManager, SignInManager<UsersModel> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Requests");
                }

                ModelState.AddModelError(string.Empty, "Invalid login");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UsersModel { UserName = model.Username, FirstName = model.FirstName, LastName = model.LastName };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (_context.Users.Count() == 1)
                    {
                        string[] roles = new [] { "Unassigned", "CEO", "TeamLeader", "Developer" };

                        foreach (var role in roles)
                        {
                            await roleManager.CreateAsync(new IdentityRole<int>(role));
                        }

                        await userManager.AddToRoleAsync(user, "CEO");
                    }

                    else
                    {
                        await userManager.AddToRoleAsync(user, "Unassigned");
                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}