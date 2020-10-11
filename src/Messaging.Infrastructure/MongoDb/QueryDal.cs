using AutoMapper;
using Messaging.Application.Query.DAL;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.Infrastructure.MongoDb
{
    public class QueryDal : IQueryDal
    {
        private readonly IMongoCollection<Message> _collection;
        private readonly IMapper _mapper;

        //singleton
        public QueryDal(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.Database);
            var database = mongoClient.GetDatabase("MessageBoard");
            _collection = database.GetCollection<Message>("Message");
            _mapper = AutoMapperConfig.CreateConfig().CreateMapper();
        }
        public async Task<GetAllMessagesResponse> GetAllMessagesAsync(GetAllMessagesRequest request, CancellationToken token)
        {
            // need to apply ordering in query and not result set really. But running out of time. So would do later
            var messages = (await _collection.Find("{}").ToListAsync()).OrderBy(m => m.CreatedDate);

            var mappedMessages = _mapper.Map<IEnumerable<Application.Query.DAL.Message>>(messages);
            return new GetAllMessagesResponse
            {
                Messages = mappedMessages
            };
        }
    }
}
