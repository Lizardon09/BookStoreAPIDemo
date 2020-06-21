using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.DTO
{

        public class BookDto
        {
            public long Id { get; set; }
            public string Title { get; set; }

            public PublisherDto Publisher { get; set; }
            public ICollection<AuthorDTO> Authors { get; set; }
        }

}
