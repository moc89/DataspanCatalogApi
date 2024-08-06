using Microsoft.AspNetCore.Mvc;

namespace DataspanCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private static readonly List<Author> Authors = new List<Author>();

        public AuthorController(ILogger<AuthorController> logger)
        {
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return Authors;
        }
    }
}
