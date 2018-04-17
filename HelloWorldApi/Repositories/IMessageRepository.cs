using System;
using System.Collections.Generic;
using HelloWorldApi.Models;

namespace HelloWorldApi.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> Messages { get; set; }
    }
}
