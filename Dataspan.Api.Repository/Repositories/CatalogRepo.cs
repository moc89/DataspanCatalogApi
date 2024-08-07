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

            Author author = await _context.Authors
                                          .Include(e=>e.BookAuthors)
                                          .ThenInclude(e => e.Book)
                                          .FirstOrDefaultAsync(e => e.Id == id);

            if (author == null)
            {
                return new Response() { AdditionalMessage = "Author not found", ErrorCode = 102 };
            }

            if (author.BookAuthors.Count > 0)
            {
                return new Response() 
                { 
                    AdditionalMessage = "Removal of an author is not allowed when at least one book is related to it", 
                    ErrorCode = 102,
                    Status = 0
                };
            }

            _context.Remove(author);
            await _context.SaveChangesAsync();

            return new Response();
        }

        public async Task<Response> CreateBook(Book book, List<int> authorIds)
        {
            Response response = new Response();

            try
            {
                // Check if all author IDs exist
                var authors = await _context.Authors.Where(a => authorIds.Contains(a.Id)).ToListAsync();
                if (authors.Count != authorIds.Count)
                {
                    response.ErrorCode = 4;
                    response.AdditionalMessage = "One or more authors not found";
                    response.Status = 0;
                    return response;
                }


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
                var query = await _context.Books
                                  .Include(b => b.BookAuthors)
                                  .ThenInclude(ba => ba.Author)
                                  .ToListAsync();

                response.book = query ?? new List<Book>();
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
                var query = await _context.Books
                                  .Include(b => b.BookAuthors)
                                  .ThenInclude(ba => ba.Author)
                                  .FirstOrDefaultAsync(e => e.Id == bookId);

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

        public async Task<Response> UpdateAuthor(int id, Author author)
        {
            Response response = new Response();

            try
            {
                // Check if the author exists
                var existingAuthor = await _context.Authors.FirstOrDefaultAsync(e => e.Id == id);
                if (existingAuthor == null)
                {
                    response.ErrorCode = 102;
                    response.AdditionalMessage = "Author not found";
                    response.Status = 0;
                    return response;
                }

                // Update the author's properties
                existingAuthor.Name = author.Name;
                existingAuthor.Surname = author.Surname;
                existingAuthor.BirthYear = author.BirthYear;

                _context.Authors.Update(existingAuthor);
                await _context.SaveChangesAsync();

                response.Status = 1;
                response.AdditionalMessage = "Author updated successfully";
            }
            catch (System.Exception ex)
            {
                response.ErrorCode = 1;
                response.AdditionalMessage = ex.Message;
                response.Status = 0;
            }

            return response;
        }

        public async Task<Response> UpdateBook(int id, Book book)
        {
            Response response = new Response();

            try
            {
                // Check if the book exists
                var existingBook = await _context.Books
                                                 .Include(b => b.BookAuthors)
                                                 .FirstOrDefaultAsync(e => e.Id == id);
                if (existingBook == null)
                {
                    response.ErrorCode = 102;
                    response.AdditionalMessage = "Book not found";
                    response.Status = 0;
                    return response;
                }

                // Check if all author IDs exist
                List<int> authorIds = book.BookAuthors.Select(x => x.AuthorId).ToList();
                var authors = await _context.Authors.Where(a => authorIds.Contains(a.Id)).ToListAsync();
                if (authors.Count != authorIds.Count)
                {
                    response.ErrorCode = 4;
                    response.AdditionalMessage = "One or more authors not found";
                    response.Status = 0;
                    return response;
                }

                // Update the book's properties
                existingBook.Title = book.Title;
                existingBook.Publisher = book.Publisher;
                existingBook.PublishedDate = book.PublishedDate;
                existingBook.Edition = book.Edition;

                // Update the book authors
                existingBook.BookAuthors.Clear();
                foreach (var bookAuthor in book.BookAuthors)
                {
                    existingBook.BookAuthors.Add(new BookAuthor
                    {
                        BookId = existingBook.Id,
                        AuthorId = bookAuthor.AuthorId
                    });
                }

                _context.Books.Update(existingBook);
                await _context.SaveChangesAsync();

                response.Status = 1;
                response.AdditionalMessage = "Book updated successfully";
            }
            catch (System.Exception ex)
            {
                response.ErrorCode = 1;
                response.AdditionalMessage = ex.Message;
                response.Status = 0;
            }

            return response;
        }
    }
}
