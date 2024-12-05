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
    public class RecebedorModelsController : Controller
    {
        private readonly ColheitaSolidariaContext _context;

        public RecebedorModelsController(ColheitaSolidariaContext context)
        {
            _context = context;
        }

        // GET: RecebedorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecebedorModel.ToListAsync());
        }

        // GET: RecebedorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebedorModel = await _context.RecebedorModel
                .FirstOrDefaultAsync(m => m.CodRecebedor == id);
            if (recebedorModel == null)
            {
                return NotFound();
            }

            return View(recebedorModel);
        }

        // GET: RecebedorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecebedorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_recebedor,n_familiar")] RecebedorModel recebedorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recebedorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recebedorModel);
        }

        // GET: RecebedorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebedorModel = await _context.RecebedorModel.FindAsync(id);
            if (recebedorModel == null)
            {
                return NotFound();
            }
            return View(recebedorModel);
        }

        // POST: RecebedorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_recebedor,n_familiar")] RecebedorModel recebedorModel)
        {
            if (id != recebedorModel.CodRecebedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recebedorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecebedorModelExists(recebedorModel.CodRecebedor))
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
            return View(recebedorModel);
        }

        // GET: RecebedorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebedorModel = await _context.RecebedorModel
                .FirstOrDefaultAsync(m => m.CodRecebedor == id);
            if (recebedorModel == null)
            {
                return NotFound();
            }

            return View(recebedorModel);
        }

        // POST: RecebedorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recebedorModel = await _context.RecebedorModel.FindAsync(id);
            if (recebedorModel != null)
            {
                _context.RecebedorModel.Remove(recebedorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecebedorModelExists(int id)
        {
            return _context.RecebedorModel.Any(e => e.CodRecebedor == id);
        }
    }
}
