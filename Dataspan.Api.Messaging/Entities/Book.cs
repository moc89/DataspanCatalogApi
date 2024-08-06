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
        public int Authors { get; set; } 
        public string Publisher { get; set; }
        public string Edition { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
