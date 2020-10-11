using Messaging.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.Validation
{
    public class Validator : IValidator
    {
        public ValidResponse Validate(Message message)
        {
            var response = new ValidResponse();

            if (message == null)
            {
                response.Code = ValidatorResponseCode.MessageNull;
                return response;
            }

            if (string.IsNullOrEmpty(message.Sender))
            {
                response.Code = ValidatorResponseCode.SenderNullOrEmpty;
                return response;
            }

            if (message.Text != null && message.Text.Length > 1024)
            {
                response.Code = ValidatorResponseCode.TextTooLong;
                return response;
            }
  
            if (message.Sender.Length > 64)
            {
                response.Code = ValidatorResponseCode.SenderNameTooLong;
                return response;
            }

            return response;
        }
    }
}
