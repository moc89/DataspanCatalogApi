using Dataspan.Api.Messaging.Entities;
using Dataspan.Api.Messaging.MessagingObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Repository.Interfaces
{
    public interface ICatalogRepo
    {
        Task<Response> CreateAuthor(Author author);
        Task<GetAuthorResponse> GetAuthors();
        Task<Response> DeleteAuthor(int id);
        Task<Response> GetAuthor(int authorId);
    }
}
