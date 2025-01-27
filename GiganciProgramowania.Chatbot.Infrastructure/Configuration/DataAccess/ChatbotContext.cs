using GiganciProgramowania.Chatbot.Domain.Messages;
using Microsoft.EntityFrameworkCore;

namespace GiganciProgramowania.Chatbot.Infrastructure.Configuration.DataAccess;

public class ChatbotContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    public ChatbotContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assemblyWithConfigurations = GetType().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
    }
}
