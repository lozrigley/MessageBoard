using Messaging.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.Validation
{
    public interface IValidator
    {
        ValidResponse Validate(Message message);
    }
}
