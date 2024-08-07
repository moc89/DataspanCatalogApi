using Dataspan.Api.Messaging.Entities;
using Dataspan.Api.Messaging.MessagingObjects;
using Dataspan.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Repository.Repositories
{
    public class CatalogRepo: ICatalogRepo
    {
        private readonly CatalogContext _context;
        public CatalogRepo(CatalogContext context)
        {
            _context = context;
        }
        public async Task<Response> CreateAuthor(Author author)
        {
            Response response = new Response();

            try
            {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                response.ErrorCode = 1;
                response.AdditionalMessage = ex.Message;
                response.Status = 0;
            }

            return response;
        }

        public async Task<GetAuthorResponse> GetAuthor(int authorId)
        {
            GetAuthorResponse response = new GetAuthorResponse();

            try
            {
                var query = await _context.Authors.FirstOrDefaultAsync(e => e.Id == authorId);

                response.author = query;
            }
            catch (System.Exception ex)
            {
                // TODO: Error Log DB will be implemented.
                response.ErrorCode = 3;
                response.AdditionalMessage = ex.Message;
                response.Status = 0;
            }

            return response;
        }

        public async Task<GetAuthorsResponse> GetAuthors()
        {
            GetAuthorsResponse response = new GetAuthorsResponse();

            try
            {
                var query = await _context.Authors.ToListAsync();

                response.authors = query;
            }
            catch (System.Exception ex)
            {
                // TODO: Error Log DB will be implemented.
                response.ErrorCode = 2;
                response.AdditionalMessage = ex.Message;
                response.Status = 0;
            }

            return response;
        }

        public async Task<Response> DeleteAuthor(int id)
        {
            if (id <= 0)
            {
                return new Response() { AdditionalMessage = "Author Id cannot be negative", ErrorCode = 101 };
            }

            Author author = await _context.Authors.FirstOrDefaultAsync(e => e.Id == id);

            if (author == null)
            {
                return new Response() { AdditionalMessage = "Author not found", ErrorCode = 102 };
            }

            _context.Remove(author);
            await _context.SaveChangesAsync();

            return new Response();
        }

        public async Task<Response> CreateBook(int authorId, Book book)
        {
            Response response = new Response();

            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                response.ErrorCode = 1;
                response.AdditionalMessage = ex.Message;
                response.Status = 0;
            }

            return response;
        }

        public async Task<GetBooksResponse> GetBooks()
        {
            GetBooksResponse response = new GetBooksResponse();

            try
            {
                var query = await _context.Books.ToListAsync();

                response.book = query;
            }
            catch (System.Exception ex)
            {
                // TODO: Error Log DB will be implemented.
                response.ErrorCode = 2;
                response.AdditionalMessage = ex.Message;
                response.Status = 0;
            }

            return response;
        }

        public async Task<Response> DeleteBook(int id)
        {
            if (id <= 0)
            {
                return new Response() { AdditionalMessage = "Book Id cannot be negative", ErrorCode = 101 };
            }

            Book book = await _context.Books.FirstOrDefaultAsync(e => e.Id == id);

            if (book == null)
            {
                return new Response() { AdditionalMessage = "Book not found", ErrorCode = 102 };
            }

            _context.Remove(book);
            await _context.SaveChangesAsync();

            return new Response();
        }

        public async Task<GetBookResponse> GetBook(int bookId)
        {
            GetBookResponse response = new GetBookResponse();

            try
            {
                var query = await _context.Books.FirstOrDefaultAsync(e => e.Id == bookId);

                response.book = query;
            }
            catch (System.Exception ex)
            {
                // TODO: Error Log DB will be implemented.
                response.ErrorCode = 3;
                response.AdditionalMessage = ex.Message;
                response.Status = 0;
            }

            return response;
        }
    }
}
