using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldApi.Models;

namespace HelloWorldApi.Repositories
{
    public class HelloWorldRepository : IMessageRepository
    {
        private List<Message> messages = new List<Message>
        {
            new Message { id = 1, message = "Hello World" },
            new Message { id = 2, message = "Hello Moon" },
            new Message { id = 3, message = "Hello Sun" }
        };
        public IEnumerable<Message> Messages {
            get { return messages; }
            set { }
        }
    }
}
