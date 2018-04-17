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
        private readonly IMessageRepository repo;
        public MessagesController(IMessageRepository repo)
        {
            this.repo = repo;
        }

        // GET v1/api/messages
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return repo.Messages.ToList();
        }

        // GET v1/api/messages/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var message = repo.Messages.FirstOrDefault(x => x.id == id);
            if (message == null)
            {
                return NotFound(id);
            }
            return new ObjectResult(message);
        }

        // POST api/messages
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT v1/api/messages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE v1/api/messages/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
