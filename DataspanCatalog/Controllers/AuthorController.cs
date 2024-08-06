using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Application.Interfaces;
using Dataspan.Api.Messaging.Entities;
using Dataspan.Api.Messaging.MessagingObjects;
using Microsoft.AspNetCore.Mvc;

namespace DataspanCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;
        private readonly ILogger _logger;

        public AuthorController(ILogger<AuthorController> logger, IAuthorServices authorServices)
        {
            _authorServices = authorServices;
            _logger = logger;   
        }

        [HttpGet]
        public async Task<GetAuthorsResponse> Get()
        {
            return await this._authorServices.GetAuthors();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorDto author)
        {
            Response result = await this._authorServices.AddAuthor(author);
            return CreatedAtAction(nameof(Get), result);
        }

        [HttpGet("{id}")]
        public async Task<GetAuthorResponse> Get(int id)
        {
            return await this._authorServices.GetAuthor(id);
        }


        [HttpDelete("{id}")]
        public async Task<Response> Delete(int id)
        {
            return await this._authorServices.DeleteAuthor(id);
        }
    }
}
