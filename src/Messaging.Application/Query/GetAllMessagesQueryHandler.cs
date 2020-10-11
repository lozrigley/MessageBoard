using MediatR;
using Messaging.Application.Query.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.Application.Query
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, GetAllMessagesResponse>
    {
        private readonly IQueryDal _dal;

        public GetAllMessagesQueryHandler(IQueryDal dal)
        {
            _dal = dal;
        }

        //public async Task<IEnumerable<Message>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        //{
        //    // This is bypassing Domain completely for now
        //    var getAllMessagesRequest = new GetAllMessagesRequest
        //    {

        //    };

        //    var response =  await _dal.GetAllMessagesAsync(getAllMessagesRequest, cancellationToken);

        //    return response.Messages;
        //}

        public async Task<GetAllMessagesResponse> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var getAllMessagesRequest = new GetAllMessagesRequest
            {

            };

            return await _dal.GetAllMessagesAsync(getAllMessagesRequest, cancellationToken);
        }
    }
}
