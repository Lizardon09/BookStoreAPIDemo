using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models.DTO;
using Test.Models.Repository;
using Microsoft.Extensions.Logging;

namespace Test.Controllers
{
	
    [Route("api/authors")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AuthorsController : ControllerBase
    {
        private readonly IDataRepository<Author, AuthorDTO> _dataRepository;

        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IDataRepository<Author, AuthorDTO> dataRepository, ILogger<AuthorsController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;
            
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult Get()
        {
            var authors = _dataRepository.GetAll();

            _logger.LogInformation("GET All Request for Authors");

            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            var author = _dataRepository.GetDto(id);
            if (author == null)
            {
                _logger.LogError("NULL return of GET Request for Author: ", id);
                return NotFound("Author not found.");
            }

            _logger.LogInformation("GET Request for Author: ", id);

            return Ok(author);
        }

        // POST: api/Authors
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            if (author is null)
            {
                return BadRequest("Author is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(author);
            return CreatedAtRoute("GetAuthor", new { Id = author.Id }, null);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest("Author is null.");
            }

            var authorToUpdate = _dataRepository.Get(id);
            if (authorToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(authorToUpdate, author);
            return NoContent();
        }
    }
}