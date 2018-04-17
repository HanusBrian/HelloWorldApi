using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloWorldApi.Repositories;
using HelloWorldApi.Models;


namespace HelloWorldApi.Controllers
{
    [Route("v1/api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IDataRepository<Message> repo;
        public MessagesController(IDataRepository<Message> repo)
        {
            this.repo = repo;
        }

        // GET v1/api/messages
        [HttpGet]
        public IActionResult Get()
        {
            List<Message> messages = repo.GetAll();
            if(messages.Any())
                return Ok(messages);
            return NoContent();
        }

        // GET v1/api/messages/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var message = repo.GetById(id);
            if (message == null)
            {
                return NotFound(id);
            }
            return Ok(message);
        }

        // POST api/messages
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            Message message = new Message() { message = value };
            if (repo.Save(message) == null)
            {
                return BadRequest();
            }
            return Ok(repo.Save(message));
        }

        // PUT v1/api/messages/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            Message message = new Message
            {
                id = id,
                message = value
            };
            Message response = repo.Save(message);
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // DELETE v1/api/messages/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Message message = repo.Delete(id);
            if(message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }
    }
}
