using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vacation_Ready;
using Vacation_Ready.Models.Requests;

namespace Vacation_Ready.Controllers
{
    public class RequestsController : Controller
    {
        private readonly VacationReadyContext _context;

        public RequestsController(VacationReadyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requests.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestsModel = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestsModel == null)
            {
                return NotFound();
            }

            return View(requestsModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateSent,UserId,FromDate,UntilDate,LeaveId,HalfDay,AttachmentUrl,Approved")] RequestsModel requestsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestsModel = await _context.Requests.FindAsync(id);
            if (requestsModel == null)
            {
                return NotFound();
            }
            return View(requestsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateSent,UserId,FromDate,UntilDate,LeaveId,HalfDay,AttachmentUrl,Approved")] RequestsModel requestsModel)
        {
            if (id != requestsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestsModelExists(requestsModel.Id))
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
            return View(requestsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestsModel = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestsModel == null)
            {
                return NotFound();
            }

            return View(requestsModel);
        }

        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestsModel = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(requestsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestsModelExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
