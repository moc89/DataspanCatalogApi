using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Application.Interfaces;
using Dataspan.Api.Application.Services;
using Dataspan.Api.Messaging.MessagingObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataspanCatalog.Controllers
{
 
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        private readonly ILogger _logger;

        public BookController(ILogger<BookController> logger, IBookServices bookServices)
        {
            _bookServices = bookServices;
            _logger = logger;
        }


        [HttpGet]
        public async Task<GetBooksResponse> Get()
        {
            return await this._bookServices.GetBooks();

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookDto book)
        {
            Response result = await this._bookServices.AddBook(book);
            return CreatedAtAction(nameof(Get), result);
        }

        [HttpGet("{id}")]
        public async Task<GetBookResponse> Get(int id)
        {
            return await this._bookServices.GetBook(id);
        }

        [HttpDelete("{id}")]
        public async Task<Response> Delete(int id)
        {
            return await this._bookServices.DeleteBook(id);
        }
    }
}
