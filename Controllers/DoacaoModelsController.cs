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
    public class DoacaoModelsController : Controller
    {
        private readonly ColheitaSolidariaContext _context;

        public DoacaoModelsController(ColheitaSolidariaContext context)
        {
            _context = context;
        }

        // GET: DoacaoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoacaoModel.ToListAsync());
        }

        // GET: DoacaoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacaoModel = await _context.DoacaoModel
                .FirstOrDefaultAsync(m => m.RecebedorModel == id);
            if (doacaoModel == null)
            {
                return NotFound();
            }

            return View(doacaoModel);
        }

        // GET: DoacaoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoacaoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_doacao,cod_recebedor,cod_doador,tipo,data_validade,descricao")] DoacaoModel doacaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doacaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doacaoModel);
        }

        // GET: DoacaoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacaoModel = await _context.DoacaoModel.FindAsync(id);
            if (doacaoModel == null)
            {
                return NotFound();
            }
            return View(doacaoModel);
        }

        // POST: DoacaoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodDoacao,CodRecebedor,CodDoador,Tipo,DataValidade,Descricao")] DoacaoModel doacaoModel)
        {
            if (id != doacaoModel.RecebedorModel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doacaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoacaoModelExists(doacaoModel.RecebedorModel))
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
            return View(doacaoModel);
        }

        // GET: DoacaoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacaoModel = await _context.DoacaoModel
                .FirstOrDefaultAsync(m => m.RecebedorModel == id);
            if (doacaoModel == null)
            {
                return NotFound();
            }

            return View(doacaoModel);
        }

        // POST: DoacaoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doacaoModel = await _context.DoacaoModel.FindAsync(id);
            if (doacaoModel != null)
            {
                _context.DoacaoModel.Remove(doacaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoacaoModelExists(int id)
        {
            return _context.DoacaoModel.Any(e => e.RecebedorModel == id);
        }
    }
}
