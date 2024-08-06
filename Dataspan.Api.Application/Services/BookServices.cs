using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Application.Services
{
    public class BookServices : IBookServices
    {
        private static readonly List<BookDto> Books = new List<BookDto>();

        Task<List<BookDto>> IBookServices.GetBooks()
        {
            return Task.FromResult(Books);
        }

        Task<BookDto> IBookServices.AddBook(int authorId, BookDto book)
        {
            book.Id = Books.Count + 1;
            book.Authors = authorId;
            Books.Add(book);
            return Task.FromResult(book);
        }
        Task<BookDto> IBookServices.GetBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
