using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryWebApp;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;


namespace LibraryWebApp.Controllers
{
    public class GenresController : Controller
    {
        private readonly LibraryContext _context;

        public GenresController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Genres
        public async Task<IActionResult> Index(string? exception)
        {
            ViewBag.Exception = exception;
            return View(await _context.Genres.ToListAsync());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Books", new { id = genre.Id, name = genre.Name });
        }

        // GET: Genres/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
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
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Import(IFormFile fileExcel)
        {
            if (ModelState.IsValid)
            {
                if (fileExcel != null)
                {
                    using (var stream = new FileStream(fileExcel.FileName, FileMode.Create))
                    {
                        await fileExcel.CopyToAsync(stream);
                        using (XLWorkbook workBook = new XLWorkbook(stream, XLEventTracking.Disabled))
                        {
                            foreach (IXLWorksheet worksheet in workBook.Worksheets)
                            {
                                try
                                {
                                    GetGenreFromWorksheet(worksheet);
                                }
                                catch(Exception e)
                                {
                                    return RedirectToAction("Index", "Genres", new { exception = "Помилка: " + e.Message });
                                }
                            }
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "admin")]
        public ActionResult Export()
        {
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var genres = _context.Genres.Include("Books").ToList();
                foreach (var c in genres)
                {
                    var worksheet = workbook.Worksheets.Add(c.Name);

                    worksheet.Cell("A1").Value = "Назва";
                    worksheet.Cell("B1").Value = "Автор 1";
                    worksheet.Cell("C1").Value = "Автор 2";
                    worksheet.Cell("D1").Value = "Автор 3";
                    worksheet.Cell("E1").Value = "Автор 4";
                    worksheet.Cell("F1").Value = "Рік видання";
                    worksheet.Cell("G1").Value = "ISBN";
                    worksheet.Cell("H1").Value = "Tag1";
                    worksheet.Cell("I1").Value = "Tag2";
                    worksheet.Cell("J1").Value = "Tag3";
                    worksheet.Row(1).Style.Font.Bold = true;
                    var books = c.Books.ToList();

                    //нумерація рядків/стовпчиків починається з індекса 1 (не 0)
                    for (int i = 0; i < books.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = books[i].Name;
                        worksheet.Cell(i + 2, 6).Value = books[i].YearWritten;
                        worksheet.Cell(i + 2, 7).Value = books[i].Isbn;

                        var ab = _context.Wrotes.Where(a => a.BookId == books[i].Id).Include("Author").ToList();
                        //більше 4-ох нікуди писати
                        int j = 0;
                        foreach (var a in ab)
                        {
                            if (j < 5)
                            {
                                worksheet.Cell(i + 2, j + 2).Value = a.Author.Name;
                                j++;
                            }
                        }
                        var tg = _context.Descriptions.Where(a => a.BookId == books[i].Id).Include("Tag").ToList();
                        //більше 3-ох нікуди писати
                        int k = 0;
                        foreach (var a in tg)
                        {
                            if (k < 4)
                            {
                                worksheet.Cell(i + 2, k + 8).Value = a.Tag.Name;
                                k++;
                            }
                        }

                    }
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"library_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }
        // GET: Genres/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }

        private bool BookExists(string? name)
        {
            return _context.Books.Any(e => e.Name == name);
        }
        private Author AddAuthor(IXLRow row, int pos)
        {
            Author author;

            var a = (from aut in _context.Authors
                        where aut.Name.Contains(row.Cell(pos).Value.ToString())
                        select aut).ToList();
            if (a.Count > 0)
            {
                author = a[0];
            }
            else
            {
                author = new Author();
                author.Name = row.Cell(pos).Value.ToString();
                //додати в контекст
                _context.Add(author);
            }
            return author;
        }
        private Tag AddTag(IXLRow row, int pos)
        {
            Tag tag;

            var a = (from aut in _context.Tags
                     where aut.Name.Contains(row.Cell(pos).Value.ToString())
                     select aut).ToList();
            if (a.Count > 0)
            {
                tag = a[0];
            }
            else
            {
                tag = new Tag();
                tag.Name = row.Cell(pos).Value.ToString();
                //додати в контекст
                _context.Add(tag);
            }
            return tag;
        }
        private void AddBook(IXLRow row, IXLWorksheet worksheet, Genre newcat)
        {
            Book book = new Book();
            book.Name = row.Cell(1).Value.ToString();
            book.Genre = newcat;
            book.YearWritten = Convert.ToInt32(row.Cell(6).Value.ToString());
            book.Isbn = Convert.ToInt32(row.Cell(7).Value.ToString());
            _context.Books.Add(book);
            if (!BookExists(book.Name))
            {
                for (int i = 2; i <= 5; i++)
                {
                    if (row.Cell(i).Value.ToString().Length > 0)
                    {
                        Wrote wr = new Wrote();
                        wr.Book = book;
                        wr.Author = AddAuthor(row, i);
                        _context.Wrotes.Add(wr);
                    }
                }
                for (int i = 8; i <= 10; i++)
                {
                    if (row.Cell(i).Value.ToString().Length > 0)
                    {
                        Description ds = new Description();
                        ds.Book = book;
                        ds.Tag = AddTag(row, i);
                        _context.Descriptions.Add(ds);
                    }
                }
            } else
            {
                throw new InvalidOperationException("Input file contains existing books.");
            }
        }
        private void GetGenreFromWorksheet(IXLWorksheet worksheet)
        {
            Genre newcat;
            var c = (from cat in _context.Genres
                     where cat.Name.Contains(worksheet.Name)
                     select cat).ToList();
            if (c.Count > 0)
            {
                newcat = c[0];
            }
            else
            {
                newcat = new Genre();
                newcat.Name = worksheet.Name;
                //newcat.Info = "from EXCEL";
                //додати в контекст
                _context.Genres.Add(newcat);
            }
            //перегляд усіх рядків                    
            foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
            {
                AddBook(row, worksheet, newcat);
            }
        }
    }
}
