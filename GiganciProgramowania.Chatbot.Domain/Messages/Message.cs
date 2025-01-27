using GiganciProgramowania.Chatbot.Domain.Messages.Properties;

namespace GiganciProgramowania.Chatbot.Domain.Messages;

public class Message
{
    public Guid MessageId { get; init; }

    private string _message;
    private string _messageRateCode;
    private bool _isUserMessage;
    private DateTime _createDate;


#pragma warning disable CS8618
    private Message()
#pragma warning restore CS8618
    {
    }

    private Message(
        string message,
        bool isUserMessage,
        DateTime createDate)
    {
        MessageId = Guid.NewGuid();
        _message = message;
        _isUserMessage = isUserMessage;
        _createDate = createDate;
        _messageRateCode = MessageRate.Missing.Code;
    }

    public static Message Create(
        string message,
        bool isUserMessage)
    {

        return new Message(
            message,
            isUserMessage,
            DateTime.Now);
    }

    public void ChangeRate(MessageRate messageRate)
    {
        _messageRateCode = messageRate.Code;
    }

    public string MessageValue => _message;
    public MessageRate MessageRate => MessageRate.OfCode(_messageRateCode);
    public bool IsUserMessage  => _isUserMessage;
    public DateTime CreateDate => _createDate;
}
