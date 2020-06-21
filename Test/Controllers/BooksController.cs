using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models.DTO;
using Test.Models.Repository;

namespace Test.Controllers
{
    [Route("api/books")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class BooksController : ControllerBase
    {
        private readonly IDataRepository<Book, BookDto> _dataRepository;

        public BooksController(IDataRepository<Book, BookDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _dataRepository.Get(id);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            return Ok(book);
        }
    }
}