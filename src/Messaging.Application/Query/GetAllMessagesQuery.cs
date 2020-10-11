using MediatR;
using Messaging.Application.Query.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Application.Query
{
    public class GetAllMessagesQuery : IRequest<IEnumerable<Message>>
    {
    }
}
