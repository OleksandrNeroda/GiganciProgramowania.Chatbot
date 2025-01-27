using GiganciProgramowania.Chatbot.Application;
using GiganciProgramowania.Chatbot.Application.Messages;
using GiganciProgramowania.Chatbot.Domain.Messages;
using GiganciProgramowania.Chatbot.Infrastructure.Configuration.DataAccess;
using GiganciProgramowania.Chatbot.Infrastructure.Configuration.Domain.Messages;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .WithExposedHeaders("Content-Type");
    });
});

builder.Services.AddDbContext<ChatbotContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "GiganciProgramowania Chatbot API",
        Version = "v1"
    });
});

builder.Services.AddScoped<IMessageRepository, MessageRepository>();

builder.Services.AddSingleton<IChatService, RandomChatService>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(ApplicationAssembly.Application);
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseCors("AllowLocalhost");
app.MapControllers();

app.Run();
