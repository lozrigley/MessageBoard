using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Messaging.Application.Command;
using Messaging.Application.Query;
using Messaging.Application.Query.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Annotations;

namespace Messaging.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Message
        [HttpGet("GetAll")]
        [SwaggerResponse(200, "Get All Messages", typeof(IEnumerable<Message>))]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var query = new GetAllMessagesQuery();
            return Ok(await _mediator.Send(query));
        }

        // POST: api/Message
        [HttpPost()]
        [SwaggerResponse(201, "Returns Id of new Message", typeof(Guid))]
        public async Task<IActionResult> Post([FromBody] SaveMessageCommand command)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            return StatusCode(201, await _mediator.Send(command));
        }

    }
}
