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
    public class CategoriasController : Controller
    {

        /// <summary>
        /// Referência a Bases de Dados
        /// </summary>
        
        private readonly ApplicationDbContext bd;

        public CategoriasController(ApplicationDbContext context)
        {
            bd = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await bd.Categorias.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = await bd.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View(); // mostra a View de nome 'Create', que está na pasta que está na pasta 'Categorias'
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] // Responde a uma resposta de browser feita em POST
        [ValidateAntiForgeryToken] //Proteção contra ataques
        public async Task<IActionResult> Create([Bind("Categoria")] Categorias novaCategoria)
        {
            //Tarefas
            // - ajustar o nome das variáveis
            // - ajustar os anotadores, neste caso concreto, eliminar ID do 'Bind'

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Add(novaCategoria);
                    await bd.SaveChangesAsync();
                }
                catch (Exception)
                {
                    // throw;
                    ModelState.AddModelError("", "Aconteceu um erro na gravação de dados.");
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(novaCategoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = await bd.Categorias.FindAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Categoria")] Categorias categoriaAlterada)
        {
            if (id != categoriaAlterada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(categoriaAlterada);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriasExists(categoriaAlterada.Id))
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
            return View(categoriaAlterada);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = await bd.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorias = await bd.Categorias.FindAsync(id);
            if (categorias != null)
            {
                bd.Categorias.Remove(categorias);
            }

            await bd.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasExists(int id)
        {
            return bd.Categorias.Any(e => e.Id == id);
        }
    }
}
