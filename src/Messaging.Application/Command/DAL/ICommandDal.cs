
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.Application.Command.DAL
{
    public interface ICommandDal
    {
        Task<SaveMessageResponse> SaveMessageAsync(SaveMessageRequest request, CancellationToken token);
    }
}
