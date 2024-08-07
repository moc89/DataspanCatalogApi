using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Application.Dtos
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Edition { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<int> AuthorIds { get; set; } // List of Author Ids
    }
}
