using System;
using Xunit;
using HelloWorldApi.Controllers;
using System.Collections.Generic;

namespace HelloWorldApi.Tests.TestControllers
{
    public class TestHelloWorldController
    {

        MessagesController ctl = new MessagesController();
        [Fact]
        public void TestControllerGetMethod()
        {
            // Arrange
            var expected = new string[] { "value1", "value2" };
            // Act
            string[] res = ctl.Get();
            // Assert
            Assert.Equal(res, expected);
        }

        [Fact]
        public void TestApiGetIdMethod()
        {
            // Arrange
            string expected = "Hello World";
            // Act
            string res = ctl.Get(1);
            // Assert
            Assert.Equal(expected, res);
        }
    }
}
