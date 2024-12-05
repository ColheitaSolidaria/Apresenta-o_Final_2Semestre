using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ColheitaSolidaria.Data;
using ColheitaSolidaria.Models;

namespace ColheitaSolidaria.Controllers
{
    public class DoadorModelsController : Controller
    {
        private readonly ColheitaSolidariaContext _context;

        public DoadorModelsController(ColheitaSolidariaContext context)
        {
            _context = context;
        }

        // GET: DoadorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoadorModel.ToListAsync());
        }

        // GET: DoadorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doadorModel = await _context.DoadorModel
                .FirstOrDefaultAsync(m => m.CodDoador == id);
            if (doadorModel == null)
            {
                return NotFound();
            }

            return View(doadorModel);
        }

        // GET: DoadorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoadorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_doador")] DoadorModel doadorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doadorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doadorModel);
        }

        // GET: DoadorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doadorModel = await _context.DoadorModel.FindAsync(id);
            if (doadorModel == null)
            {
                return NotFound();
            }
            return View(doadorModel);
        }

        // POST: DoadorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodDoador")] DoadorModel doadorModel)
        {
            if (id != doadorModel.CodDoador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doadorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoadorModelExists(doadorModel.CodDoador))
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
            return View(doadorModel);
        }

        // GET: DoadorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doadorModel = await _context.DoadorModel
                .FirstOrDefaultAsync(m => m.CodDoador == id);
            if (doadorModel == null)
            {
                return NotFound();
            }

            return View(doadorModel);
        }

        // POST: DoadorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doadorModel = await _context.DoadorModel.FindAsync(id);
            if (doadorModel != null)
            {
                _context.DoadorModel.Remove(doadorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoadorModelExists(int id)
        {
            return _context.DoadorModel.Any(e => e.CodDoador == id);
        }
    }
}
