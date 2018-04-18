using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldApi.Models
{
    public class MessageContext : IDataContext<Message>
    {
        private List<Message> messages = new List<Message>
        {
            new Message { id = 1, message = "Hello World" },
            new Message { id = 2, message = "Hello Moon" },
            new Message { id = 3, message = "Hello Sun" }
        };

        private int nextId = 4;

        public List<Message> GetAll()
        {
            return messages;
        }

        public Message GetById(int id)
        {
            return GetMessageById(id);
        }

        public Message Save(Message input)
        {
            Message message = GetMessageById(input.id);
            if (message == null)
            {
                message = new Message
                {
                    id = nextId++,
                    message = input.message
                };

                messages.Add(message);
                return message;
            }

            message.message = input.message;
            return input;
        }

        public Message Delete(int id)
        {
            var message = GetMessageById(id);
            if (message != null)
            {
                messages.Remove(message);
                return message;
            }
            return null;
        }

        private Message GetMessageById(int id)
        {
            if(id != 0)
            {
                return messages.FirstOrDefault(x => x.id == id);
            }
            return null;
        }
    }
}
