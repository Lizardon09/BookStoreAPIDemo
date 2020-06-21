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
    [Route("api/publishers")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PublishersController : ControllerBase
    {
        private readonly IDataRepository<Publisher, PublisherDto> _dataRepository;

        public PublishersController(IDataRepository<Publisher, PublisherDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _dataRepository.Get(id);
            if (publisher == null)
            {
                return NotFound("The Publisher record couldn't be found.");
            }

            _dataRepository.Delete(publisher);
            return NoContent();
        }
    }
}