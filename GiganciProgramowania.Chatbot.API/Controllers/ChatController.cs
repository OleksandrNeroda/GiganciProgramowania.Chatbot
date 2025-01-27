using MediatR;
using Microsoft.AspNetCore.Mvc;
using GiganciProgramowania.Chatbot.Application.Messages.SendMessage;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using GiganciProgramowania.Chatbot.Application.Messages.GetAllMessages;
using GiganciProgramowania.Chatbot.Application.Messages.ChangeMessageRate;

namespace GiganciProgramowania.Chatbot.API.Controllers
{
    [ApiController]
    [Route("Chat")]
    public class ChatController : ControllerBase
    {
        private readonly ISender _sender;

        public ChatController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Send")]
        public async Task<ActionResult> SendMessage(SendMessageCommand command)
        {
            var message = await _sender.Send(command);
            return Ok(message);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var messages = await _sender.Send(new GetAllMessagesQuery());
            return Ok(messages);
        }

        [HttpPut("Rate/{messageId}")]
        public async Task<ActionResult> RateMessage([FromRoute]Guid messageId, [FromBody] ChangeMessageRateCommand command)
        {
            var result = await _sender.Send(new ChangeMessageRateCommand(messageId, command.MessageRateCode));
            return Ok(result);
        }

    }
}
