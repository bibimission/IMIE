using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Budget.Models;
using BudgetDeuxiemeTentative.Data;

namespace BudgetDeuxiemeTentative.Controllers
{
    public class BanquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BanquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Banques
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banque.ToListAsync());
        }

        // GET: Banques/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banque = await _context.Banque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banque == null)
            {
                return NotFound();
            }

            return View(banque);
        }

        // GET: Banques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Ville")] Banque banque)
        {
            if (ModelState.IsValid)
            {
                banque.Id = Guid.NewGuid();
                _context.Add(banque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banque);
        }

        // GET: Banques/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banque = await _context.Banque.FindAsync(id);
            if (banque == null)
            {
                return NotFound();
            }
            return View(banque);
        }

        // POST: Banques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nom,Ville")] Banque banque)
        {
            if (id != banque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanqueExists(banque.Id))
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
            return View(banque);
        }

        // GET: Banques/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banque = await _context.Banque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banque == null)
            {
                return NotFound();
            }

            return View(banque);
        }

        // POST: Banques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var banque = await _context.Banque.FindAsync(id);
            _context.Banque.Remove(banque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BanqueExists(Guid id)
        {
            return _context.Banque.Any(e => e.Id == id);
        }
    }
}
