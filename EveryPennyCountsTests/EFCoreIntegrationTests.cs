using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EveryPennyCountsTests
{
    /*this code is based on code found here
     https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
    I've tried everything to get this code to work and visual studio just refuses to even run it
    I've tried using Xunit annotations and the default test annotations, I've tried with different datarows, I've tried with different method names, I've tried 
    using run until failure, it just doesn't want to run them*/
    [TestClass]
    public class EFCoreIntegrationTests
    {
        public readonly WebApplicationFactory<Program> _factory;

        public EFCoreIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [TestMethod]
        [DataRow("/Index")]
        public async void Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.AreEqual("text/html; charset=utf-8",
                response.Content.Headers.ContentType?.ToString());
        }
    }
}
