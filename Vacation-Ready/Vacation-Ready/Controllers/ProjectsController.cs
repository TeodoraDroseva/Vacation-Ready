using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vacation_Ready;
using Vacation_Ready.Models.Projects;

namespace Vacation_Ready.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly VacationReadyContext _context;

        public ProjectsController(VacationReadyContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.Include(pt => pt.Team).ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsModel = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectsModel == null)
            {
                return NotFound();
            }

            return View(projectsModel);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,TeamId")] ProjectsModel projectsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectsModel);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsModel = await _context.Projects.FindAsync(id);
            if (projectsModel == null)
            {
                return NotFound();
            }
            return View(projectsModel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,TeamId")] ProjectsModel projectsModel)
        {
            if (id != projectsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsModelExists(projectsModel.Id))
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
            return View(projectsModel);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsModel = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectsModel == null)
            {
                return NotFound();
            }

            return View(projectsModel);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectsModel = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(projectsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsModelExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
