using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController1 : ControllerBase
    {
        private readonly LibraryContext _context;

        public ChartsController1(LibraryContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData2")]
        public JsonResult JsonData2()
        {
            var Authors = _context.Authors.Include(a => a.Wrotes).ToList();
            List<object> catAuthor = new List<object>();

            catAuthor.Add(new[] { "Автор", "Кількість книжок" });

            foreach (var c in Authors)
            {
                catAuthor.Add(new object[] { c.Name, c.Wrotes.Count });
            }
            return new JsonResult(catAuthor);
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ChartsController(LibraryContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData1")]
        public JsonResult JsonData1()
        {
            var Genres = _context.Genres.Include(b => b.Books).ToList();
            List<object> catBook = new List<object>();

            catBook.Add(new[] { "Жанр", "Кількість книжок" });

            foreach (var c in Genres)
            {
                catBook.Add(new object[] { c.Name, c.Books.Count });
            }
            return new JsonResult(catBook);
        }
        [HttpGet("JsonData2")]
        public JsonResult JsonData2()
        {
            var Authors = _context.Authors.Include(a => a.Wrotes).ToList();
            List<object> catAuthor = new List<object>();

            catAuthor.Add(new[] { "Автор", "Кількість книжок" });

            foreach (var c in Authors)
            {
                catAuthor.Add(new object[] { c.Name, c.Wrotes.Count });
            }
            return new JsonResult(catAuthor);
        }
    }
}
