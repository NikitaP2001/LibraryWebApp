using System;
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
                return NotFound();
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
        public IActionResult Create(int? BookId)
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            if (BookId == null)
            {
                ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name");
            }
            ViewBag.BookId = BookId;
            return View();
        }

        // POST: Wrotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? BookId, [Bind("Id,BookId,AuthorId")] Wrote wrote)
        {
            ViewBag.BookId = BookId;
            wrote.BookId = ViewBag.BookId;
            var Book = await _context.Books.FindAsync(BookId);
            if (ModelState.IsValid)
            {
                _context.Add(wrote);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Wrotes", new { id = Book.Id, name = Book.Name });
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", wrote.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", wrote.BookId);
            return RedirectToAction("Index", "Wrotes", new { id =Book.Id, name = Book.Name });
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
            var book = await _context.Books.FindAsync(wrote.BookId);
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", wrote.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", wrote.BookId);
            return RedirectToAction("Index", "Wrotes", new { id = book.Id, name = book.Name });
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
            var book = await _context.Books.FindAsync(wrote.BookId);
            return RedirectToAction("Index", "Wrotes", new { id = book.Id, name = book.Name });
        }

        private bool WroteExists(int id)
        {
            return _context.Wrotes.Any(e => e.Id == id);
        }
    }
}
