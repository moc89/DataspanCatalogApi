using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Application.Interfaces;
using Dataspan.Api.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataspanCatalog.Controllers
{
 
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<BookDto>> Get()
        {
            return await this._bookServices.GetBooks();

        }

        [HttpPost("{authorId}")]
        public async Task<ActionResult> Post(int authorId, [FromBody] BookDto book)
        {
            BookDto result = await this._bookServices.AddBook(authorId, book);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            return await this._bookServices.GetBook(id);
        }
    }
}
