
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.Application.Query.DAL
{
    public interface IQueryDal
    {
        Task<GetAllMessagesResponse> GetAllMessagesAsync(GetAllMessagesRequest request, CancellationToken token);
    }
}
