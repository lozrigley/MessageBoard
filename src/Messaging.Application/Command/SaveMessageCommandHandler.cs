using MediatR;
using Messaging.Application.Command.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.Application.Command
{
    public class SaveMessageCommandHandler : IRequestHandler<SaveMessageCommand, SaveMessageResponse>
    {
        public Task<SaveMessageResponse> Handle(SaveMessageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
