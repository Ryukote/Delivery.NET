using Delivery.NET.RoyalMail.Validations;
using Delivery.NET.RoyalMail.Values.Requests;
using Xunit;

namespace Delivery.NET.Tests
{
    public class TokenRequestValidationTests
    {
        [Fact]
        public void ClientIdIsNotValid()
        {
            var validator = new AuthenticationValidation();

            var tokenRequest = new TokenRequest()
            {
                ClientId = "",
                ClientSecret = "TestClientSecret",
                Password = "TestPassword1",
                Username = "test@testparcel.net"
            };

            var result = validator.Validate(tokenRequest);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void ClientSecretIsNotValid()
        {
            var validator = new AuthenticationValidation();

            var tokenRequest = new TokenRequest()
            {
                ClientId = "TestClientId",
                ClientSecret = "",
                Password = "TestPassword1",
                Username = "test@testparcel.net"
            };

            var result = validator.Validate(tokenRequest);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void PasswordIsNotValid()
        {
            var validator = new AuthenticationValidation();

            var tokenRequest = new TokenRequest()
            {
                ClientId = "TestClientId",
                ClientSecret = "TestClientSecret",
                Password = "",
                Username = "test@testparcel.net"
            };

            var result = validator.Validate(tokenRequest);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void UsernameIsEmpty()
        {
            var validator = new AuthenticationValidation();

            var tokenRequest = new TokenRequest()
            {
                ClientId = "TestClientId",
                ClientSecret = "TestClientSecret",
                Password = "TestPassword1",
                Username = ""
            };

            var result = validator.Validate(tokenRequest);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void ClientIdIsMissingCharacter()
        {
            var validator = new AuthenticationValidation();

            var tokenRequest = new TokenRequest()
            {
                ClientId = "TestClientId",
                ClientSecret = "TestClientSecret",
                Password = "TestPassword1",
                Username = "test@testparcel.net"
            };

            var result = validator.Validate(tokenRequest);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void UsernameIsNotValidEmail()
        {
            var validator = new AuthenticationValidation();

            var tokenRequest = new TokenRequest()
            {
                ClientId = "TestClientId",
                ClientSecret = "TestClientSecret",
                Password = "TestPassword1",
                Username = "testtestparcel.net"
            };

            var result = validator.Validate(tokenRequest);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void EntireTokenRequestIsValid()
        {
            var validator = new AuthenticationValidation();

            var tokenRequest = new TokenRequest()
            {
                ClientId = "Test-Client-Id",
                ClientSecret = "TestClientSecret",
                Password = "TestPassword1",
                Username = "test@testparcel.net"
            };

            var result = validator.Validate(tokenRequest);

            Assert.True(result.IsValid);
        }
    }
}
