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
        private readonly ICommandDal _dal;

        public SaveMessageCommandHandler(ICommandDal dal)
        {
            _dal = dal;
        }

        public async Task<SaveMessageResponse> Handle(SaveMessageCommand request, CancellationToken cancellationToken)
        {
            //use automapper for this
            var saveMessageRequest = new SaveMessageRequest
            {
                Sender = request.Sender,
                Text = request.Text
            };

           return await _dal.SaveMessageAsync(saveMessageRequest, cancellationToken);
        }
    }
}
