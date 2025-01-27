using GiganciProgramowania.Chatbot.Domain.Messages;
using MediatR;

namespace GiganciProgramowania.Chatbot.Application.Messages.GetAllMessages;

public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, List<MessageDto>>
{
    private readonly IMessageRepository _messageRepository;

    public GetAllMessagesQueryHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<List<MessageDto>> Handle(GetAllMessagesQuery query, CancellationToken cancellationToken)
    {
        var messages = (await _messageRepository.GetAll(cancellationToken)).OrderBy(x => x.CreateDate);

        return messages
        .Select(message => new MessageDto
        {
            MessageId = message.MessageId,
            Message = message.MessageValue,
            MessageRateCode = message.MessageRate.Code,
            IsUserMessage = message.IsUserMessage,
            CreateDate = message.CreateDate
        })
        .ToList();
    }
}