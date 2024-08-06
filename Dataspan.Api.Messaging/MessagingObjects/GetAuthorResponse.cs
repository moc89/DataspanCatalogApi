using Dataspan.Api.Messaging.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataspan.Api.Messaging.MessagingObjects
{
    public class GetAuthorResponse: Response
    {
        public List<Author> authors { get; set; }
    }
}
