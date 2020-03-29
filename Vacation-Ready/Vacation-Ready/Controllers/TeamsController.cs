using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vacation_Ready;
using Vacation_Ready.Models.Teams;

namespace Vacation_Ready.Controllers
{
    public class TeamsController : Controller
    {
        private readonly VacationReadyContext _context;

        public TeamsController(VacationReadyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamsModel = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamsModel == null)
            {
                return NotFound();
            }

            return View(teamsModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TeamsModel teamsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamsModel = await _context.Teams.FindAsync(id);
            if (teamsModel == null)
            {
                return NotFound();
            }
            return View(teamsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TeamsModel teamsModel)
        {
            if (id != teamsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamsModelExists(teamsModel.Id))
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
            return View(teamsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamsModel = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamsModel == null)
            {
                return NotFound();
            }

            return View(teamsModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamsModel = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(teamsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamsModelExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}