using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.DTO
{
    public class AuthorDTO
    {
        public AuthorDTO()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public AuthorContactDto AuthorContact { get; set; }
    }
}
