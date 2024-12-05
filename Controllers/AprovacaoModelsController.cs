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
    public class AprovacaoModelsController : Controller
    {
        private readonly ColheitaSolidariaContext _context;

        public AprovacaoModelsController(ColheitaSolidariaContext context)
        {
            _context = context;
        }

        // GET: AprovacaoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AprovacaoModel.ToListAsync());
        }

        // GET: AprovacaoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprovacaoModel = await _context.AprovacaoModel
                .FirstOrDefaultAsync(m => m.CodDoacao == id);
            if (aprovacaoModel == null)
            {
                return NotFound();
            }

            return View(aprovacaoModel);
        }

        // GET: AprovacaoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AprovacaoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_doacao,cod_adm,data_aprovacao")] AprovacaoModel aprovacaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aprovacaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aprovacaoModel);
        }

        // GET: AprovacaoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprovacaoModel = await _context.AprovacaoModel.FindAsync(id);
            if (aprovacaoModel == null)
            {
                return NotFound();
            }
            return View(aprovacaoModel);
        }

        // POST: AprovacaoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_doacao,cod_adm,data_aprovacao")] AprovacaoModel aprovacaoModel)
        {
            if (id != aprovacaoModel.CodDoacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aprovacaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AprovacaoModelExists(aprovacaoModel.CodDoacao))
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
            return View(aprovacaoModel);
        }

        // GET: AprovacaoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aprovacaoModel = await _context.AprovacaoModel
                .FirstOrDefaultAsync(m => m.CodDoacao == id);
            if (aprovacaoModel == null)
            {
                return NotFound();
            }

            return View(aprovacaoModel);
        }

        // POST: AprovacaoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aprovacaoModel = await _context.AprovacaoModel.FindAsync(id);
            if (aprovacaoModel != null)
            {
                _context.AprovacaoModel.Remove(aprovacaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AprovacaoModelExists(int id)
        {
            return _context.AprovacaoModel.Any(e => e.CodDoacao == id);
        }
    }
}
