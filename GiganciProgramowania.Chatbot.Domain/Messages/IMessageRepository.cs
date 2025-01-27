using GiganciProgramowania.Chatbot.Domain.Commons;

namespace GiganciProgramowania.Chatbot.Domain.Messages;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<IEnumerable<Message>> GetAll(CancellationToken cancellationToken);
}
