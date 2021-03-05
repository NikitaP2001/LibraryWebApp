﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryWebApp;

namespace LibraryWebApp.Controllers
{
    public class WrotesController : Controller
    {
        private readonly LibraryContext _context;

        public WrotesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Wrotes
        public async Task<IActionResult> Index(int? id, string? name)
        {
            if (id == null) {
                if(ViewBag.BookId == null)
                    return RedirectToAction("Index", "Genres");
                else id = ViewBag.BookId;
            }
            ViewBag.WroteId = id;
            ViewBag.BookId = id;
            ViewBag.BookName = name;
            var wrotesByGenre = _context.Wrotes.Where(b => b.BookId == id).Include(b => b.Book).Include(b => b.Author);
            return View(await wrotesByGenre.ToListAsync());
        }

        // GET: Wrotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wrote = await _context.Wrotes
                .Include(w => w.Author)
                .Include(w => w.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wrote == null)
            {
                return NotFound();
            }

            return View(wrote);
        }

        // GET: Wrotes/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name");
            return View();
        }

        // POST: Wrotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,AuthorId")] Wrote wrote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wrote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", wrote.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", wrote.BookId);
            return View(wrote);
        }

        // GET: Wrotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wrote = await _context.Wrotes.FindAsync(id);
            if (wrote == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", wrote.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", wrote.BookId);
            return View(wrote);
        }

        // POST: Wrotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,AuthorId")] Wrote wrote)
        {
            if (id != wrote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wrote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WroteExists(wrote.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", wrote.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", wrote.BookId);
            return View(wrote);
        }

        // GET: Wrotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wrote = await _context.Wrotes
                .Include(w => w.Author)
                .Include(w => w.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wrote == null)
            {
                return NotFound();
            }

            return View(wrote);
        }

        // POST: Wrotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wrote = await _context.Wrotes.FindAsync(id);
            _context.Wrotes.Remove(wrote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WroteExists(int id)
        {
            return _context.Wrotes.Any(e => e.Id == id);
        }
    }
}