using MediatR;
using Messaging.Application.Command.DAL;
using Messaging.Domain.Validation;
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
        private readonly IValidator _validator;

        public SaveMessageCommandHandler(ICommandDal dal, IValidator validator)
        {
            _dal = dal;
            _validator = validator;
        }

        public async Task<SaveMessageResponse> Handle(SaveMessageCommand request, CancellationToken cancellationToken)
        {
            //use automapper for this
            var saveMessageRequest = new SaveMessageRequest
            {
                Sender = request.Sender,
                Text = request.Text
            };

            var domainMessage = new Domain.Model.Message
            {
                Sender = request.Sender,
                Text = request.Text
            };

            var validationResponse = _validator.Validate(domainMessage);

            if(!validationResponse.IsValid)
            {
                throw new ArgumentException($"Error with Message Code {validationResponse.Code}");
            }

           return await _dal.SaveMessageAsync(saveMessageRequest, cancellationToken);
        }
    }
}
