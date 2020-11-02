using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using WebApp.TesteIntegracao.Fixtures;
using Xunit;

namespace WebApp.TesteIntegracao.Scenarios
{
    public class ValuesTest
    {
        private readonly TestContext _testContext;
        public ValuesTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Theory]
        [InlineData("3")]
        [InlineData("5")]
        [InlineData("10")]
        public async Task Values_GetById_ValuesReturnOkResponse(string id)
        {
            var response = await _testContext.Client.GetAsync($"/api/values/{id}");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("xxx")]
        public async Task Values_GetById_ReturnsBadRequestResponse(string id)
        {
            var response = await _testContext.Client.GetAsync($"/api/values/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("3")]
        [InlineData("5")]
        public async Task Values_GetById_CorrectContentType(string id)
        {
            var response = await _testContext.Client.GetAsync($"/api/values/{id}");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }
    }
}
