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
    public class BookServices : IBookServices
    {
        private readonly ICatalogRepo _catalogRepo;

        public BookServices(ICatalogRepo catalogRepo)
        {
            _catalogRepo = catalogRepo;
        }

        async Task<GetBooksResponse> IBookServices.GetBooks()
        {
            return await _catalogRepo.GetBooks();
        }

        async Task<Response> IBookServices.AddBook(BookDto book)
        {
            Book newBook = new Book
            {
                Title = book.Title,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate,
                Edition = book.Edition,
                BookAuthors = book.AuthorIds.Select(x => new BookAuthor { AuthorId = x }).ToList()
            };

            return await _catalogRepo.CreateBook(newBook, book.AuthorIds);
        }
        async Task<GetBookResponse> IBookServices.GetBook(int id)
        {
            return await _catalogRepo.GetBook(id);
        }
        async Task<Response> IBookServices.DeleteBook(int id)
        {
            return await _catalogRepo.DeleteBook(id);
        }

        async Task<Response> IBookServices.UpdateBook(int id, BookDto book)
        {
            Book updatedBook = new Book
            {
                Title = book.Title,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate,
                Edition = book.Edition,
                BookAuthors = book.AuthorIds.Select(x => new BookAuthor { AuthorId = x }).ToList()
            };
            return await _catalogRepo.UpdateBook(id, updatedBook);
        }
    }
}
