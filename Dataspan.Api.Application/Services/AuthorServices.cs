using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Application.Interfaces;
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
        Task<AuthorDto> IAuthorServices.AddAuthor(AuthorDto author)
        {
            author.Id = Authors.Count + 1;
            Authors.Add(author);
            return Task.FromResult(author);
        }

        Task<List<AuthorDto>> IAuthorServices.GetAuthors()
        {
            return Task.FromResult(Authors);
        }
    }
}
