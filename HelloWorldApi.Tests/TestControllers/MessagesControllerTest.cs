using System;
using Xunit;
using Moq;
using HelloWorldApi.Controllers;
using HelloWorldApi.Models;
using HelloWorldApi.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Tests.TestControllers
{
    public class MessagesControllerTest
    {


        public MessagesControllerTest()
        {
            //ctx.Setup(mc => mc.GetAll()).Returns(messages);

            //repo.Setup(mr => mr.GetById(1)).Returns(messages.Find(m => m.id == 1));
        }

        [Fact]
        public void GetAllMethodWithResults()
        {
            // Arrange
            Mock<IDataRepository<Message>> repo = new Mock<IDataRepository<Message>>();
            MessagesController controller = new MessagesController(repo.Object);
            List<Message> messages = messages = new List<Message>
            {
                new Message { id = 1, message = "Hello World" },
                new Message { id = 2, message = "Hello Moon" },
                new Message { id = 3, message = "Hello Sun" }
            };

            repo.Setup(mr => mr.GetAll()).Returns(messages);

            OkObjectResult expectedRes = new OkObjectResult(messages);

            // Act
            IActionResult res = controller.Get();
            
            // Assert
            Assert.Equal(expectedRes.StatusCode, ((ObjectResult) res).StatusCode);
            Assert.Equal(expectedRes.Value, ((ObjectResult) res).Value);
        }

        [Fact]
        public void GetAllMethodWithNoResults()
        {
            // Arrange
            Mock<IDataRepository<Message>> repo = new Mock<IDataRepository<Message>>();
            MessagesController controller = new MessagesController(repo.Object);
            List<Message> messages = new List<Message> { };
            
            repo.Setup(mr => mr.GetAll()).Returns(messages);

            NoContentResult expectedRes = new NoContentResult();

            // Act
            IActionResult res = controller.Get();

            // Assert
            Assert.Equal(expectedRes.StatusCode, ((NoContentResult)res).StatusCode);
        }

        [Fact]
        public void GetByIdWithResult()
        {
            // Arrange
            Mock<IDataRepository<Message>> repo = new Mock<IDataRepository<Message>>();
            MessagesController controller = new MessagesController(repo.Object);
            List<Message> messages = messages = new List<Message>
            {
                new Message { id = 1, message = "Hello World" },
                new Message { id = 2, message = "Hello Moon" },
                new Message { id = 3, message = "Hello Sun" }
            };
            repo.Setup(mr => mr.GetById(1)).Returns(messages.Find(x => x.id == 1));
            Message expectedMessage = messages.Find(x => x.id == 1);

            OkObjectResult expectedResult = new OkObjectResult(expectedMessage);

            // Act
            IActionResult result = controller.Get(1);

            // Assert
            Assert.Equal(expectedResult.StatusCode, ((ObjectResult)result).StatusCode);
            Assert.Equal(expectedMessage, ((ObjectResult)result).Value);
        }

        [Fact]
        public void GetByIdNoResult()
        {
            // Arrange
            Mock<IDataRepository<Message>> repo = new Mock<IDataRepository<Message>>();
            MessagesController controller = new MessagesController(repo.Object);
            List<Message> messages = messages = new List<Message>
            {
                new Message { id = 1, message = "Hello World" },
                new Message { id = 2, message = "Hello Moon" },
                new Message { id = 3, message = "Hello Sun" }
            };
            repo.Setup(mr => mr.GetById(5)).Returns(messages.Find(x => x.id == 5));

            NotFoundObjectResult expectedResult = new NotFoundObjectResult((int) 5);

            // Act
            IActionResult result = controller.Get(5);

            // Assert
            Assert.Equal(expectedResult.StatusCode, ((ObjectResult)result).StatusCode);
            Assert.Equal(expectedResult.Value, ((ObjectResult)result).Value);
        }
    }
}
