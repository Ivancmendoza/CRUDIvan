using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDMVC.Models;

namespace CRUDMVC.Controllers
{
    public class TblEmpleadosController : Controller
    {
        private readonly dbCRUDWebAppContext _context;

        public TblEmpleadosController(dbCRUDWebAppContext context)
        {
            _context = context;
        }

        // GET: TblEmpleadoes
        public async Task<IActionResult> Index()
        {
              return _context.TblEmpleados != null ? 
                          View(await _context.TblEmpleados.ToListAsync()) :
                          Problem("Entity set 'dbCRUDWebAppContext.TblEmpleados'  is null.");
        }

        // GET: TblEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblEmpleados == null)
            {
                return NotFound();
            }

            var tblEmpleado = await _context.TblEmpleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblEmpleado == null)
            {
                return NotFound();
            }

            return View(tblEmpleado);
        }

        // GET: TblEmpleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Puesto,Salario,Telefono,Correo")] TblEmpleado tblEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmpleado);
        }

        // GET: TblEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblEmpleados == null)
            {
                return NotFound();
            }

            var tblEmpleado = await _context.TblEmpleados.FindAsync(id);
            if (tblEmpleado == null)
            {
                return NotFound();
            }
            return View(tblEmpleado);
        }

        // POST: TblEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Puesto,Salario,Telefono,Correo")] TblEmpleado tblEmpleado)
        {
            if (id != tblEmpleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmpleadoExists(tblEmpleado.Id))
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
            return View(tblEmpleado);
        }

        // GET: TblEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblEmpleados == null)
            {
                return NotFound();
            }

            var tblEmpleado = await _context.TblEmpleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblEmpleado == null)
            {
                return NotFound();
            }

            return View(tblEmpleado);
        }

        // POST: TblEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblEmpleados == null)
            {
                return Problem("Entity set 'dbCRUDWebAppContext.TblEmpleados'  is null.");
            }
            var tblEmpleado = await _context.TblEmpleados.FindAsync(id);
            if (tblEmpleado != null)
            {
                _context.TblEmpleados.Remove(tblEmpleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpleadoExists(int id)
        {
          return (_context.TblEmpleados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
