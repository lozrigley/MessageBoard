using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.Model
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Sender { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
