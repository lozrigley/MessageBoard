using System.Collections.Generic;

namespace Messaging.Application.Query.DAL
{
    public class GetAllMessagesResponse
    {
        public IEnumerable<Message> Messages { get; set; }
    }
}