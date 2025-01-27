namespace GiganciProgramowania.Chatbot.Application.Messages;

public class MessageDto
{
    public Guid MessageId { get; set; }
    public string Message { get; set; } = string.Empty;
    public string MessageRateCode { get; set; } = string.Empty;
    public bool IsUserMessage { get; set; }

    public DateTime CreateDate { get; set; }
}
