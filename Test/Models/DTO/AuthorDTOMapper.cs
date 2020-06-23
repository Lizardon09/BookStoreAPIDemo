using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.DTO;

namespace Test.Models.DTO
{
    public class AuthorDtoMapper
    {
        public static AuthorDTO MapToDto(Author author)
        {

            if (author == null)
            {
                return new AuthorDTO();
            }

            return new AuthorDTO()
            {
                Id = author.Id,
                Name = author.Name,

                AuthorContact = new AuthorContactDto()
                {
                    AuthorId = author.Id,
                    Address = author.AuthorContact.Address,
                    ContactNumber = author.AuthorContact.ContactNumber
                }
            };
        }
    }
}
