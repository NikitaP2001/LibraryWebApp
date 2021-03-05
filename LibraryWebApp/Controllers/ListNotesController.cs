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
    public class ListNotesController : Controller
    {
        private readonly LibraryContext _context;

        public ListNotesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: ListNotes
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.ListNotes.Include(l => l.Book).Include(l => l.Reader);
            return View(await libraryContext.ToListAsync());
        }

        // GET: ListNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listNote = await _context.ListNotes
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listNote == null)
            {
                return NotFound();
            }

            return View(listNote);
        }

        // GET: ListNotes/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name");
            ViewData["ReaderId"] = new SelectList(_context.Readers, "Id", "Login");
            return View();
        }

        // POST: ListNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,ReaderId,BookId")] ListNote listNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", listNote.BookId);
            ViewData["ReaderId"] = new SelectList(_context.Readers, "Id", "Login", listNote.ReaderId);
            return View(listNote);
        }

        // GET: ListNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listNote = await _context.ListNotes.FindAsync(id);
            if (listNote == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", listNote.BookId);
            ViewData["ReaderId"] = new SelectList(_context.Readers, "Id", "Login", listNote.ReaderId);
            return View(listNote);
        }

        // POST: ListNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,ReaderId,BookId")] ListNote listNote)
        {
            if (id != listNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListNoteExists(listNote.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", listNote.BookId);
            ViewData["ReaderId"] = new SelectList(_context.Readers, "Id", "Login", listNote.ReaderId);
            return View(listNote);
        }

        // GET: ListNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listNote = await _context.ListNotes
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listNote == null)
            {
                return NotFound();
            }

            return View(listNote);
        }

        // POST: ListNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listNote = await _context.ListNotes.FindAsync(id);
            _context.ListNotes.Remove(listNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListNoteExists(int id)
        {
            return _context.ListNotes.Any(e => e.Id == id);
        }
    }
}
