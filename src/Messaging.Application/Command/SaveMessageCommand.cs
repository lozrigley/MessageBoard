using MediatR;
using Messaging.Application.Command.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Application.Command
{
    public class SaveMessageCommand : SaveMessageRequest, IRequest<SaveMessageResponse>
    {
    }
}
