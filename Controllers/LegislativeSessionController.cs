using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreedoniaGovernment.Data;
using FreedoniaGovernment.Models;

namespace FreedoniaGovernment.Controllers
{
    public class LegislativeSessionController : Controller
    {
        private readonly FreedoniaContext _context;

        public LegislativeSessionController(FreedoniaContext context)
        {
            _context = context;
        }

        // GET: LegislativeSession
        public async Task<IActionResult> Index()
        {
            return View(await _context.LegislativeSession.ToListAsync());
        }

        // GET: LegislativeSession/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legislativeSession = await _context.LegislativeSession
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legislativeSession == null)
            {
                return NotFound();
            }

            return View(legislativeSession);
        }

        // GET: LegislativeSession/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LegislativeSession/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SessionIndex,StartYear,EndYear")] LegislativeSession legislativeSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legislativeSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legislativeSession);
        }

        // GET: LegislativeSession/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legislativeSession = await _context.LegislativeSession.FindAsync(id);
            if (legislativeSession == null)
            {
                return NotFound();
            }
            return View(legislativeSession);
        }

        // POST: LegislativeSession/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SessionIndex,StartYear,EndYear")] LegislativeSession legislativeSession)
        {
            if (id != legislativeSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legislativeSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegislativeSessionExists(legislativeSession.Id))
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
            return View(legislativeSession);
        }

        // GET: LegislativeSession/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legislativeSession = await _context.LegislativeSession
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legislativeSession == null)
            {
                return NotFound();
            }

            return View(legislativeSession);
        }

        // POST: LegislativeSession/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legislativeSession = await _context.LegislativeSession.FindAsync(id);
            if (legislativeSession != null)
            {
                _context.LegislativeSession.Remove(legislativeSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegislativeSessionExists(int id)
        {
            return _context.LegislativeSession.Any(e => e.Id == id);
        }
    }
}
