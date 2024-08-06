using Dataspan.Api.Application.Dtos;
using Dataspan.Api.Application.Interfaces;
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
        public async Task<IEnumerable<AuthorDto>> Get()
        {
            return await this._authorServices.GetAuthors();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorDto author)
        {
            AuthorDto result = await this._authorServices.AddAuthor(author);
            return CreatedAtAction(nameof(Get), new { id = author.Id }, author);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            return await this._authorServices.GetAuthor(id);
        }
    }
}
