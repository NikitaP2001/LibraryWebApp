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
    public class ChartsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ChartsController(LibraryContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData")]
        public JsonResult JsonData() {
        var Genres = _context.Genres.Include(b => b.Books).ToList();
            List<object> catBook = new List<object>();

            catBook.Add(new[] { "Жанр", "Кількість книжок" });

            foreach (var c in Genres)
            {
                catBook.Add(new object[] { c.Name, c.Books.Count });
            }
            return new JsonResult(catBook);
        }

    }
}
