using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Budget.Data;
using Budget.Models;

namespace Budget.Controllers
{
    public class ComptesController : Controller
    {
        private readonly BudgetDbContext _context;

        public ComptesController(BudgetDbContext context)
        {
            _context = context;
        }

        // GET: Comptes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compte.ToListAsync());
        }

        // GET: Comptes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compte = await _context.Compte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compte == null)
            {
                return NotFound();
            }

            return View(compte);
        }

        // GET: Comptes/Create
        public IActionResult Create()
        {
            Compte model = new Compte();
            return View(model);
        }

        // POST: Comptes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Type,IdPersonne,IdBanque")] Compte compte)
        {
            if (ModelState.IsValid)
            {
                compte.Id = Guid.NewGuid();
                _context.Add(compte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compte);
        }

        // GET: Comptes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compte = await _context.Compte.FindAsync(id);
            if (compte == null)
            {
                return NotFound();
            }
            return View(compte);
        }

        // POST: Comptes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Numero,Type,IdPersonne,IdBanque")] Compte compte)
        {
            if (id != compte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompteExists(compte.Id))
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
            return View(compte);
        }

        // GET: Comptes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compte = await _context.Compte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compte == null)
            {
                return NotFound();
            }

            return View(compte);
        }

        // POST: Comptes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var compte = await _context.Compte.FindAsync(id);
            _context.Compte.Remove(compte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompteExists(Guid id)
        {
            return _context.Compte.Any(e => e.Id == id);
        }
    }
}
