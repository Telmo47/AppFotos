﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppFotos.Data;
using AppFotos.Models;

namespace AppFotos.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtilizadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
            //procurar na BD todos os utilizadores e listá-los, entregando, de seguida, esses dados à View
            //SELECT*
            //FROM Utilizadores
            
            return View(await _context.Utilizadores.ToListAsync());
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Não esquecer!
            //Adequar o nome das variaveis às suas funções (ctrl r r)
            //TODAS!
            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nome,Morada,CodPostal,Pais,NIF,Telemovel")] Utilizadores utilizador)
        {
            if (ModelState.IsValid)
            {
                //Corrigir os dados do código postal
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nome,Morada,CodPostal,Pais,NIF,Telemovel")] Utilizadores utilizador)
        {
            if (id != utilizador.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadoresExists(utilizador.id))
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
            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador != null)
            {
                _context.Utilizadores.Remove(utilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadoresExists(int id)
        {
            return _context.Utilizadores.Any(e => e.id == id);
        }
    }
}
