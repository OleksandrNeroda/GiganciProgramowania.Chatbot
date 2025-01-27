using MediatR;

namespace GiganciProgramowania.Chatbot.Application.Messages.GetAllMessages;

public class GetAllMessagesQuery : IRequest<List<MessageDto>>
{
    public GetAllMessagesQuery()
    {
    }
}
