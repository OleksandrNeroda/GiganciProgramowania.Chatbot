using MediatR;

namespace GiganciProgramowania.Chatbot.Application.Messages.SendMessage;

public class SendMessageCommand : IRequest<MessageDto>
{
    public string Message { get; }

    public SendMessageCommand(string message)
    {
        Message = message;
    }
}
