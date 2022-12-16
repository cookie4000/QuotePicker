using DIFunction.Interface;
using DIFunction.Template;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DIFunction.Test
{
    public class UnitTest
    {
        [Fact]
        public async Task MyTestMehod()
        {
            // Arrange
            Mock<IQuoteBank> mock = new Mock<IQuoteBank>();
            Quote expected = new Quote("Test", "Test");
            mock.Setup(_ => _.getQuote()).Returns(expected);
            var subject = new QuoteFunction(mock.Object);

            //Act        
            IActionResult result = await subject.Run(Mock.Of<HttpRequest>(), Mock.Of<ILogger>());
            var objectResult = result as OkObjectResult;
            var actual = objectResult.Value as Quote;

            //Assert
            Assert.Equal(actual.author, expected.author);
            Assert.Equal(actual.quote, expected.quote);
        }
    }
}