using GiganciProgramowania.Chatbot.Domain.Messages;
using GiganciProgramowania.Chatbot.Infrastructure.Configuration.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GiganciProgramowania.Chatbot.Infrastructure.Configuration.Domain.Messages;

public class MessageRepository : IMessageRepository
{
    private readonly ChatbotContext _chatbotContext;

    public MessageRepository(ChatbotContext chatbotContext)
    {
        _chatbotContext = chatbotContext;
    }

    public void Add(Message entity)
    {
        _chatbotContext.Messages.Add(entity);
    }

    public async Task CommitAsync()
    {
        await _chatbotContext.SaveChangesAsync();
    }

    public ValueTask<Message> Get(Guid id, CancellationToken cancellationToken)
    {
        return _chatbotContext.Messages.FindAsync(new object?[] { id }, cancellationToken: cancellationToken)!;
    }

    public async Task<IEnumerable<Message>> GetAll(CancellationToken cancellationToken)
    {
        return await _chatbotContext.Messages.ToListAsync(cancellationToken);
    }

}
