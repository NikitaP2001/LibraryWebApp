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
    public class PublishedsController : Controller
    {
        private readonly LibraryContext _context;

        public PublishedsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Publisheds
        public async Task<IActionResult> Index(int? id, string? name)
        {
            if (id == null) return RedirectToAction("Genres", "Index");
            ViewBag.BookId = id;
            ViewBag.BookName = name;
            var publishbybook = _context.Publisheds.Where(b => b.BookId == id).Include(b => b.Book);
            return View(await publishbybook.ToListAsync());
        }

        // GET: Publisheds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var published = await _context.Publisheds
                .Include(p => p.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (published == null)
            {
                return NotFound();
            }

            return View(published);
        }

        // GET: Publisheds/Create
        public IActionResult Create(int BookId)
        {
            ViewBag.BookId = BookId;
            return View();
        }

        // POST: Publisheds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int BookId, [Bind("Id,Office,Year,BookId")] Published published)
        {
            published.BookId = BookId;
            if (ModelState.IsValid)
            {
                _context.Add(published);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Publisheds", new { id = BookId });
            }
            return RedirectToAction("Index", "Publisheds", new { id = BookId });
        }

        // GET: Publisheds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var published = await _context.Publisheds.FindAsync(id);
            if (published == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", published.BookId);
            return View(published);
        }

        // POST: Publisheds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Office,Year,BookId")] Published published)
        {
            if (id != published.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(published);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublishedExists(published.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", published.BookId);
            return View(published);
        }

        // GET: Publisheds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var published = await _context.Publisheds
                .Include(p => p.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (published == null)
            {
                return NotFound();
            }

            return View(published);
        }

        // POST: Publisheds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var published = await _context.Publisheds.FindAsync(id);
            _context.Publisheds.Remove(published);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublishedExists(int id)
        {
            return _context.Publisheds.Any(e => e.Id == id);
        }
    }
}
