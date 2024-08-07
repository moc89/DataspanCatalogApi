using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Messaging.Entities;
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
        Task<GetAuthorsResponse> GetAuthors();
        Task<Response> AddAuthor(AuthorDto author);
        Task<GetAuthorResponse> GetAuthor(int id);   
        Task<Response> DeleteAuthor(int id);
        Task<Response> UpdateAuthor(int id, AuthorDto author);
    }
}
