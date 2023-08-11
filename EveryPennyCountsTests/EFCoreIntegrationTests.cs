using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EveryPennyCountsTests
{
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
