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

        async Task<Response> IBookServices.AddBook(int authorId, BookDto book)
        {
            Book newBook = new Book
            {
                Title = book.Title,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate,
                Authors = authorId,
                Edition = book.Edition,
            };

            Response response = await _catalogRepo.CreateBook(authorId, newBook);

            return response;
        }
        async Task<GetBookResponse> IBookServices.GetBook(int id)
        {
            return await _catalogRepo.GetBook(id);
        }
        async Task<Response> IBookServices.DeleteBook(int id)
        {
            return await _catalogRepo.DeleteBook(id);
        }
    }
}
