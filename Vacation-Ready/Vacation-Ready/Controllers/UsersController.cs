using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacation_Ready.Models;

namespace Vacation_Ready.Controllers
{
    public class UsersController : Controller
    {
        private readonly VacationReadyContext _context;

        public UsersController(VacationReadyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.Include(user => user.UserTeams).ThenInclude(ut => ut.Team).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersModel == null)
            {
                return NotFound();
            }

            return View(usersModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _context.Users.FindAsync(id);
            if (usersModel == null)
            {
                return NotFound();
            }
            return View(usersModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,PasswordHash,FirstName,LastName")] UsersModel usersModel)
        {
            if (id != usersModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersModelExists(usersModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usersModel);
        }

        [HttpGet]
        [Authorize(Roles = "CEO")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersModel == null)
            {
                return NotFound();
            }

            return View(usersModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "CEO")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersModel = await _context.Users.FindAsync(id);
            _context.Users.Remove(usersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersModelExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
