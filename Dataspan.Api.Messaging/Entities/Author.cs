using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Messaging.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }

        // Navigation property for the many-to-many relationship with Book
        public List<BookAuthor> BookAuthors { get; set; }

    }
}
