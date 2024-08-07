using Dataspan.Api.Messaging.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Messaging.MessagingObjects
{
    public class GetBookResponse: Response
    {
        public Book book { get; set; }
    }
}
