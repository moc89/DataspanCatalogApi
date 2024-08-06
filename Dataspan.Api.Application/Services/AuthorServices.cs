using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Application.Interfaces;
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
        private static readonly List<AuthorDto> Authors = new List<AuthorDto>();

        private readonly ICatalogRepo _catalogRepo;

        public AuthorServices(ICatalogRepo catalogRepo)
        {
            _catalogRepo = catalogRepo;
        }


        Task<AuthorDto> IAuthorServices.AddAuthor(AuthorDto author)
        {
            author.Id = Authors.Count + 1;
            Authors.Add(author);
            return Task.FromResult(author);
        }

        async Task<GetAuthorResponse> IAuthorServices.GetAuthors()
        {
            GetAuthorResponse response = await _catalogRepo.GetAuthors();

            return response;
        }

        Task<AuthorDto> IAuthorServices.GetAuthor(int id)
        {
            return Task.FromResult(Authors.FirstOrDefault(a => a.Id == id));
        }
    }
}
