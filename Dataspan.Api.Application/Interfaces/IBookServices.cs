using Dataspan.Api.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Application.Interfaces
{
    public interface IBookServices
    {
        Task<List<BookDto>> GetBooks();
        Task<BookDto> AddBook(int authorId, BookDto book);
        Task<BookDto> GetBook(int id);   
    }
}
