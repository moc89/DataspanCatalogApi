using Dataspan.Api.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Application.Interfaces
{
    public interface IAuthorServices
    {
        Task<List<AuthorDto>> GetAuthors();
        Task<AuthorDto> AddAuthor(AuthorDto author);
        Task<AuthorDto> GetAuthor(int id);   
    }
}
