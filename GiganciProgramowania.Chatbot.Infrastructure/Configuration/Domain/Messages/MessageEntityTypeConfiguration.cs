using GiganciProgramowania.Chatbot.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiganciProgramowania.Chatbot.Infrastructure.Configuration.Domain.Messages;

public class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages");

        builder.HasKey(t => t.MessageId);

        builder.Property("_message").HasColumnName("Message");
        builder.Property("_messageRateCode").HasColumnName("MessageRateCode");
        builder.Property("_isUserMessage").HasColumnName("IsUserMessage");
        builder.Property("_createDate").HasColumnName("CreateDate");
    }
}
