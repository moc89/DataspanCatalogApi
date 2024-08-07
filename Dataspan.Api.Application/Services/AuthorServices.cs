using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Application.Interfaces;
using Dataspan.Api.Messaging.Entities;
using Dataspan.Api.Messaging.MessagingObjects;
using Dataspan.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Application.Services
{
    public class AuthorServices : IAuthorServices
    {

        private readonly ICatalogRepo _catalogRepo;

        public AuthorServices(ICatalogRepo catalogRepo)
        {
            _catalogRepo = catalogRepo;
        }

        async Task<GetAuthorsResponse> IAuthorServices.GetAuthors()
        {
            return await _catalogRepo.GetAuthors();
        }

        async Task<Response> IAuthorServices.AddAuthor(AuthorDto author)
        {
            Author newAuthor = new Author
            {
                Name = author.Name,
                Surname = author.Surname,
                BirthYear = author.BirthYear
            };

            return await _catalogRepo.CreateAuthor(newAuthor);
        }

        async Task<GetAuthorResponse> IAuthorServices.GetAuthor(int id)
        {
            return await _catalogRepo.GetAuthor(id);

        }

        async Task<Response> IAuthorServices.DeleteAuthor(int id)
        {
            return await _catalogRepo.DeleteAuthor(id);
        }
    }
}
