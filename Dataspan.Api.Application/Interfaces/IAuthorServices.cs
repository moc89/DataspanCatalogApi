using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Messaging.MessagingObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Application.Interfaces
{
    public interface IAuthorServices
    {
        Task<GetAuthorResponse> GetAuthors();
        Task<AuthorDto> AddAuthor(AuthorDto author);
        Task<AuthorDto> GetAuthor(int id);   
    }
}
