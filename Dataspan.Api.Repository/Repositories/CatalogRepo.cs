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
        private static readonly List<Author> Authors = new List<Author>();

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

        public Task<Response> DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAuthorResponse> GetAuthors()
        {
            GetAuthorResponse response = new GetAuthorResponse();

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
    }
}
