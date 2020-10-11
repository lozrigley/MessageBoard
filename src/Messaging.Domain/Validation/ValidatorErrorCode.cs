using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.Validation
{
    public enum ValidatorResponseCode
    {
        Passed,
        MessageNull,
        SenderNullOrEmpty,
        TextTooLong,
        SenderNameTooLong,
    }
}
