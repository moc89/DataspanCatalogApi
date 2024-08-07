using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Messaging.MessagingObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Application.Interfaces
{
    public interface IBookServices
    {
        Task<GetBooksResponse> GetBooks();
        Task<Response> AddBook(int authorId, BookDto book);
        Task<GetBookResponse> GetBook(int id);
        Task<Response> DeleteBook(int id);
    }
}
