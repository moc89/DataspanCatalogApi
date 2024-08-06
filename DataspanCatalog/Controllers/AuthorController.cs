using Dataspan.Api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataspanCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private static readonly List<Author> Authors = new List<Author>();
        private readonly IAuthorServices _authorsServices;
        private readonly ILogger _logger;

        public AuthorController(ILogger<AuthorController> logger, IAuthorServices authorServices)
        {
            _authorsServices = authorServices;
            _logger = logger;   
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return Authors;
        }
    }
}
