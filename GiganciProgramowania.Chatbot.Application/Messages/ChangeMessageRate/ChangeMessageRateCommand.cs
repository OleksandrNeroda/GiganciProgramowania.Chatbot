using MediatR;
namespace GiganciProgramowania.Chatbot.Application.Messages.ChangeMessageRate;

public class ChangeMessageRateCommand : IRequest<Unit>
{
    public Guid MessageId { get; }

    public string MessageRateCode { get; }

    public ChangeMessageRateCommand(Guid messageId, string messageRateCode)
    {
        MessageId = messageId;
        MessageRateCode = messageRateCode;
    }
}