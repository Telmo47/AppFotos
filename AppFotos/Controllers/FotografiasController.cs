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
    public class FotografiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FotografiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fotografias
        public async Task<IActionResult> Index()
        {
            /*Interrogação à BD feita em LINQ <=> SQL
             * SELECT * 
             * FROM Fotografias f INNER JOIN Categorias c ON f.CategoriaFK = C.Id
             *                    INNER JOIN Utilizadores u ON f.DonoFK = u.Id
             */

            //l pequeno em listaFotografias porque a variavel é local
            var listaFotografias = _context.Fotografias.Include(f => f.Categoria).Include(f => f.Dono);
            return View(await listaFotografias.ToListAsync());
        }

        // GET: Fotografias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*Interrogação à BD feita em LINQ <=> SQL
             * SELECT * 
             * FROM Fotografias f INNER JOIN Categorias c ON f.CategoriaFK = C.Id
             *                    INNER JOIN Utilizadores u ON f.DonoFK = u.Id
             * WHERE f.Id = id
             */

            var fotografia = await _context.Fotografias
                .Include(f => f.Categoria)
                .Include(f => f.Dono)
                .FirstOrDefaultAsync(m => m.id == id);
            if (fotografia == null)
            {
                return NotFound();
            }

            return View(fotografia);
        }

        // GET: Fotografias/Create
        public IActionResult Create()
        {
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id");
            ViewData["DonoFK"] = new SelectList(_context.Utilizadores, "id", "id");
            return View();
        }

        // POST: Fotografias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Titulo,Descricao,Ficheiro,Data,Preco,CategoriaFK,DonoFK")] Fotografias fotografia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotografia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id", fotografia.CategoriaFK);
            ViewData["DonoFK"] = new SelectList(_context.Utilizadores, "id", "id", fotografia.DonoFK);
            return View(fotografia);
        }

        // GET: Fotografias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografia = await _context.Fotografias.FindAsync(id);
            if (fotografia == null)
            {
                return NotFound();
            }
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id", fotografia.CategoriaFK);
            ViewData["DonoFK"] = new SelectList(_context.Utilizadores, "id", "id", fotografia.DonoFK);
            return View(fotografia);
        }

        // POST: Fotografias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Titulo,Descricao,Ficheiro,Data,Preco,CategoriaFK,DonoFK")] Fotografias fotografia)
        {
            if (id != fotografia.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotografia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografiasExists(fotografia.id))
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
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "Id", "Id", fotografia.CategoriaFK);
            ViewData["DonoFK"] = new SelectList(_context.Utilizadores, "id", "id", fotografia.DonoFK);
            return View(fotografia);
        }

        // GET: Fotografias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografia = await _context.Fotografias
                .Include(f => f.Categoria)
                .Include(f => f.Dono)
                .FirstOrDefaultAsync(m => m.id == id);
            if (fotografia == null)
            {
                return NotFound();
            }

            return View(fotografia);
        }

        // POST: Fotografias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotografia = await _context.Fotografias.FindAsync(id);
            if (fotografia != null)
            {
                _context.Fotografias.Remove(fotografia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotografiasExists(int id)
        {
            return _context.Fotografias.Any(e => e.id == id);
        }
    }
}
