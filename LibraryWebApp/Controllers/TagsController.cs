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
    public class TagsController : Controller
    {
        private readonly LibraryContext _context;

        public TagsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Tags
        public async Task<IActionResult> Index(int? BookId, string? name)
        {
            ViewBag.BookId = BookId;
            ViewBag.BookName = name;
            return View(await _context.Tags.ToListAsync());
        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(int? id, int? Bookid, string? Bookname)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: Tags/Create
        public IActionResult Create(int? Bookid, string? Bookname)
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? Bookid, string? Bookname, [Bind("Id,Name,Description")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Tags", new { id = Bookid, name = Bookname });
            }
            return RedirectToAction("Index", "Tags", new { id = Bookid, name = Bookname });
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(int? id, int? Bookid, string? Bookname)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            ViewBag.BookId = Bookid;
            ViewBag.BookName = Bookname;
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int? Bookid, string? Bookname, [Bind("Id,Name,Description")] Tag tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Tags", new { id = ViewBag.BookId, name = ViewBag.BookName });
            }
            return RedirectToAction("Index", "Tags", new { id = ViewBag.BookId, name = ViewBag.BookName });
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id, int? Bookid, string? Bookname)
        {
            ViewBag.BookId = Bookid;
            ViewBag.BookName = Bookname;
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int? Bookid, string? Bookname)
        {
            var tag = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Tags", new { id = ViewBag.BookId, name = ViewBag.BookName });
        }

        private bool TagExists(int id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}
