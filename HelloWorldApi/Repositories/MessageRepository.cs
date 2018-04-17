using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldApi.Models;

namespace HelloWorldApi.Repositories
{
    public class MessageRepository : IDataRepository<Message>
    {
        private readonly IDataContext<Message> ctx;
        public MessageRepository(IDataContext<Message> ctx)
        {
            this.ctx = ctx;
        }

        public Message Delete(int id)
        {
            return ctx.Delete(id);
        }

        public List<Message> GetAll()
        {
            return ctx.GetAll();
        }

        public Message GetById(int id)
        {
            return ctx.GetById(id);
        }

        public Message Save(Message t)
        {
            return ctx.Save(t);
        }
    }
}
