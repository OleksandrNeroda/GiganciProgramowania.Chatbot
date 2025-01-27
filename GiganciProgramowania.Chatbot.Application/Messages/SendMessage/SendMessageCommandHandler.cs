using GiganciProgramowania.Chatbot.Domain.Messages;
using MediatR;

namespace GiganciProgramowania.Chatbot.Application.Messages.SendMessage;

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, MessageDto>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IChatService _chatService;

    public SendMessageCommandHandler(IMessageRepository messageRepository, IChatService chatService)
    {
        _messageRepository = messageRepository;
        _chatService = chatService;
    }

    public async Task<MessageDto> Handle(SendMessageCommand command, CancellationToken cancellationToken)
    {

        var message = Message.Create(command.Message, true);
        _messageRepository.Add(message);


        var AIResponse = await _chatService.GenerateResponse(command.Message);
        var AIMessage = Message.Create(AIResponse, false);
        _messageRepository.Add(AIMessage);


        await _messageRepository.CommitAsync();

        return new MessageDto()
        {
            MessageRateCode = AIMessage.MessageRate.Code,
            IsUserMessage = AIMessage.IsUserMessage,
            Message = AIMessage.MessageValue,
            MessageId = AIMessage.MessageId
        };
    }
}
