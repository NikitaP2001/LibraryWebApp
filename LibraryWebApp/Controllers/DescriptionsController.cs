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
    public class DescriptionsController : Controller
    {
        private readonly LibraryContext _context;

        public DescriptionsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Descriptions
        public async Task<IActionResult> Index(int? id, string? name)
        {
            ViewBag.BookId = id;
            ViewBag.BookName = name;
            var libraryContext = _context.Descriptions.Where(b => b.BookId == id).Include(d => d.Book).Include(d => d.Tag);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Descriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions
                .Include(d => d.Book)
                .Include(d => d.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (description == null)
            {
                return NotFound();
            }

            return View(description);
        }

        // GET: Descriptions/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name");
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name");
            return View();
        }

        // POST: Descriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TagId,BookId")] Description description)
        {
            int BookId = description.BookId;                        //Get bookid for redirecttoaction
            var book = await _context.Books.FindAsync(BookId);
            string BookName = book.Name;
            //----------------------------------------------------------------
            var Desc = _context.Descriptions;   //Checks that it is no copy of connection
            foreach(var d in Desc)
            {
                if (d.BookId == ViewBag.BookId && d.TagId == ViewBag.TagId)
                {
                    return RedirectToAction("Index", "Descriptions", new { id = BookId, name = BookName });
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(description);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Descriptions", new { id = BookId, name = BookName });
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", description.BookId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", description.TagId);
            return RedirectToAction("Index", "Descriptions", new { id = BookId, name = BookName });
        }

        // GET: Descriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", description.BookId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", description.TagId);
            return View(description);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TagId,BookId")] Description description)
        {
            if (id != description.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(description);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescriptionExists(description.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", description.BookId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", description.TagId);
            return View(description);
        }

        // GET: Descriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions
                .Include(d => d.Book)
                .Include(d => d.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (description == null)
            {
                return NotFound();
            }

            return View(description);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var description = await _context.Descriptions.FindAsync(id);
            int BookId = description.BookId;
            var book = await _context.Books.FindAsync(BookId);
            string BookName = book.Name;
            _context.Descriptions.Remove(description);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Descriptions", new { id = BookId, name = BookName });
        }

        private bool DescriptionExists(int id)
        {
            return _context.Descriptions.Any(e => e.Id == id);
        }
    }
}
