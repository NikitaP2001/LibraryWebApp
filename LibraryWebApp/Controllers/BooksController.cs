using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LibraryWebApp.Models;
using LibraryWebApp.ViewModels;
using LibraryWebApp;

namespace LibraryWebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;
        private readonly UserManager<User> _userManager;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(int? id, string? name, string SearchString)
        {
            var Books = from m in _context.Books
                        select m;
            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewBag.Title = "Книги";
                ViewBag.BooksAboutMes = "Результат пошуку книги " + SearchString;
                Books = Books.Where(s => s.Name.Contains(SearchString));
                return View(await Books.ToListAsync());
            }
            if ( id == null)
            {
                ViewBag.Title = "Всі книги";
                ViewBag.BooksAboutMes = "Список всіх книг";
                var AllBooks = _context.Books.Include(b => b.Genre);
                return View(await AllBooks.ToListAsync());
            }
            ViewBag.GenreId = id;
            ViewBag.Title = "Книги за жанром";
            ViewBag.BooksAboutMes = "Список книг за жанром " + name;
            var booksByGenre = _context.Books.Where(b => b.GenreId == id).Include(b => b.Genre);
            return View(await booksByGenre.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.BookId = book.Id;
            ViewBag.BookName = book.Name;
            var AuthorsByBook = _context.Books.Where(b => b.Id == id)
                .Include(b => b.Comments)
                .ThenInclude(c => (c as Comment).Reader);
            return View(AuthorsByBook);
        }

        // GET: Books/Create
        public IActionResult Create(int? genreId)
        {
            ViewBag.GenreId = genreId;
            ViewBag.GenreId = genreId;
            ViewBag.GenreName = _context.Genres.Where(c => c.Id == genreId).FirstOrDefault().Name;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int genreId, [Bind("Id,Name,YearWritten,Isbn,GenreId")] Book book)
        {
            book.GenreId = genreId;
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Books", new { id = genreId, name = _context.Genres.Where(c => c.Id == genreId).FirstOrDefault().Name });
            }
            return RedirectToAction("Index", "Books", new { id = genreId, name = _context.Genres.Where(c => c.Id == genreId).FirstOrDefault().Name });
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", book.GenreId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,YearWritten,Isbn,GenreId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", book.GenreId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
