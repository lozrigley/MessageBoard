using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Infrastructure.MongoDb
{
    public class Message
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement]
        public string Text { get; set; }

        [BsonElement]
        public string Sender { get; set; }

        [BsonElement]
        public DateTime CreatedDate { get; set; }
    }
}
