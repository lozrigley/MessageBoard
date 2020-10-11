using Messaging.Application.Command.DAL;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.Infrastructure.MongoDb
{
    public class CommandDal : ICommandDal
    {
        private readonly IMongoCollection<Message> _collection;

        //singleton
        public CommandDal(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.Database);
            var database = mongoClient.GetDatabase("MessageBoard");
            _collection = database.GetCollection<Message>("Message");
        }

        public async Task<SaveMessageResponse> SaveMessageAsync(SaveMessageRequest request, CancellationToken token)
        {

            var guid = Guid.NewGuid();
            //use automapper
            var message = new Message
            {
                CreatedDate = DateTime.UtcNow,
                Id = guid.ToString(),
                Sender = request.Sender,
                Text = request.Text
            };
            await _collection.InsertOneAsync(message);

            return new SaveMessageResponse
            {
                Id = guid
            };
        }
    }
}
