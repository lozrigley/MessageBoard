using Messaging.Application.Query.DAL;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.Infrastructure.MongoDb
{
    public class QueryDal : IQueryDal
    {
        private readonly IMongoCollection<Message> _collection;

        //singleton
        public QueryDal(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.Database);
            var database = mongoClient.GetDatabase("MessageBoard");
            _collection = database.GetCollection<Message>("Message");
        }
        public async Task<GetAllMessagesResponse> GetAllMessagesAsync(GetAllMessagesRequest request, CancellationToken token)
        {
            var messages = await _collection.Find("{}").ToListAsync();

            return new GetAllMessagesResponse();
        }
    }
}
