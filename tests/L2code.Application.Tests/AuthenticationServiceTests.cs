using Microsoft.AspNetCore.Http;
using Xunit;

namespace L2code.Application.Tests
{
    [Collection(nameof(AuthenticationServiceCollection))]
    public class AuthenticationServiceTests
    {
        private readonly FixtureService _fixture;

        public AuthenticationServiceTests(FixtureService fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "GenerateToken_ShouldReturnUnauthorized_WhenUserDoesNotExist")]
        public void GenerateToken_ShouldReturnUnauthorized_WhenUserDoesNotExist()
        {
            var service = _fixture.GetAuthenticationService();
            var requestMock = _fixture.GenerateUserfail();

            var result = service.GenerateToken(requestMock);

            Assert.Equal(StatusCodes.Status401Unauthorized, result.StatusCode);
            Assert.Empty(result.Token);
        }

        [Fact(DisplayName = "GenerateToken_ShouldReturnToken")]
        public void GenerateToken_ShouldReturnToken()
        {
            var service = _fixture.GetAuthenticationService();
            var requestMock = _fixture.GenerateUser();

            var result = service.GenerateToken(requestMock);

            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.NotEmpty(result.Token);
        }
    }
}