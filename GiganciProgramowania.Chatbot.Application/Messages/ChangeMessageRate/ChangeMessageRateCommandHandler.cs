using GiganciProgramowania.Chatbot.Domain.Messages;
using GiganciProgramowania.Chatbot.Domain.Messages.Properties;
using MediatR;

namespace GiganciProgramowania.Chatbot.Application.Messages.ChangeMessageRate;

public class ChangeMessageRateCommandHandler : IRequestHandler<ChangeMessageRateCommand, Unit>
{
    private readonly IMessageRepository _messageRepository;

    public ChangeMessageRateCommandHandler(IMessageRepository messageRepository, IChatService chatService)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Unit> Handle(ChangeMessageRateCommand query, CancellationToken cancellationToken)
    {

        var messageToUpdate = await _messageRepository.Get(query.MessageId, cancellationToken);

        if (messageToUpdate != null)
        {
            messageToUpdate.ChangeRate(MessageRate.OfCode(query.MessageRateCode));
        }
        else
        {
            throw new Exception("Message not found");
        }

        await _messageRepository.CommitAsync();

        return Unit.Value;
    }
}
