using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Messaging.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Edition { get; set; }
        public DateTime PublishedDate { get; set; }

        // Navigation property for the many-to-many relationship with Author
        public List<BookAuthor> BookAuthors { get; set; }

    }
}
