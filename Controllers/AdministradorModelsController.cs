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
    public class AdministradorModelsController : Controller
    {
        private readonly ColheitaSolidariaContext _context;

        public AdministradorModelsController(ColheitaSolidariaContext context)
        {
            _context = context;
        }

        // GET: AdministradorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdministradorModel.ToListAsync());
        }

        // GET: AdministradorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradorModel = await _context.AdministradorModel
                .FirstOrDefaultAsync(m => m.CodAdm == id);
            if (administradorModel == null)
            {
                return NotFound();
            }

            return View(administradorModel);
        }

        // GET: AdministradorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministradorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cod_adm,CNPJ,Senha")] AdministradorModel administradorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administradorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administradorModel);
        }

        // GET: AdministradorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradorModel = await _context.AdministradorModel.FindAsync(id);
            if (administradorModel == null)
            {
                return NotFound();
            }
            return View(administradorModel);
        }

        // POST: AdministradorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cod_adm,CNPJ,Senha")] AdministradorModel administradorModel)
        {
            if (id != administradorModel.CodAdm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administradorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorModelExists(administradorModel.CodAdm))
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
            return View(administradorModel);
        }

        // GET: AdministradorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradorModel = await _context.AdministradorModel
                .FirstOrDefaultAsync(m => m.CodAdm == id);
            if (administradorModel == null)
            {
                return NotFound();
            }

            return View(administradorModel);
        }

        // POST: AdministradorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administradorModel = await _context.AdministradorModel.FindAsync(id);
            if (administradorModel != null)
            {
                _context.AdministradorModel.Remove(administradorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorModelExists(int id)
        {
            return _context.AdministradorModel.Any(e => e.CodAdm == id);
        }
    }
}
