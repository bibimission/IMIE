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
    public class EcrituresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EcrituresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ecritures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ecriture.ToListAsync());
        }

        // GET: Ecritures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecriture = await _context.Ecriture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecriture == null)
            {
                return NotFound();
            }

            return View(ecriture);
        }

        // GET: Ecritures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ecritures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Libelle,Debit,Montant,IdCompte")] Ecriture ecriture)
        {
            if (ModelState.IsValid)
            {
                ecriture.Id = Guid.NewGuid();
                _context.Add(ecriture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ecriture);
        }

        // GET: Ecritures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecriture = await _context.Ecriture.FindAsync(id);
            if (ecriture == null)
            {
                return NotFound();
            }
            return View(ecriture);
        }

        // POST: Ecritures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Date,Libelle,Debit,Montant,IdCompte")] Ecriture ecriture)
        {
            if (id != ecriture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ecriture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EcritureExists(ecriture.Id))
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
            return View(ecriture);
        }

        // GET: Ecritures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecriture = await _context.Ecriture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecriture == null)
            {
                return NotFound();
            }

            return View(ecriture);
        }

        // POST: Ecritures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ecriture = await _context.Ecriture.FindAsync(id);
            _context.Ecriture.Remove(ecriture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EcritureExists(Guid id)
        {
            return _context.Ecriture.Any(e => e.Id == id);
        }
    }
}
