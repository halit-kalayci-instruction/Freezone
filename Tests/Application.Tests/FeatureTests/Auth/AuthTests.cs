using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Tests.Mocks.Configurations;
using Application.Tests.Mocks.Repositories.Auth;
using Freezone.Core.Mailing;
using Freezone.Core.Mailing.MailKit;
using Freezone.Core.Security.Authenticator.Email;
using Freezone.Core.Security.Authenticator.Otp;
using Freezone.Core.Security.JWT;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Auth.Commands.Login.LoginCommand;

namespace Application.Tests.FeatureTests.Auth
{
    public class AuthTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private IAuthService _authService;
        private IConfiguration _configuration;

        public AuthTests()
        {
            _userRepository = MockUserRepository.GetUserRepositoryMock();
            _authBusinessRules = new AuthBusinessRules(_userRepository.Object);

            Mock<IUserOperationClaimRepository> _userOperationClaimRepository = MockUserOperationClaimRepository.GetUserOperationClaimRepositoryMock();

            Mock<IRefreshTokenRepository> _refreshTokenRepository = MockRefreshTokenRepository.GetRefreshTokenRepositoryMock();

            Mock<IUserEmailAuthenticatorRepository> _userEmailAuthenticatorRepository = MockUserEmailAuthenticatorRepository.GetUserEmailAuthenticatorRepositoryMock();

            Mock<IUserOtpAuthenticatorRepository> _userOtpAuthenticatorRepository = MockUserOtpAuthRepository.GetUserOtpAuthenticatorMock();

            Mock<IUserTitleDefinitonRepository> _userTitleDefRepository = MockUserTitleDefinitionRepository.GetUserTitleDefinitionMock();

            Mock<ITitleOperationClaimRepository> _titleOperationClaimsRepository = MockTitleOperationClaimRepository.GetTitleOperationClaimMock();

            _configuration = MockConfiguration.GetConfigurationMock();

            ITokenHelper tokenHelper = new JwtHelper(_configuration);
            IEmailAuthenticatorHelper emailAuthenticatorHelper = new EmailAuthenticatorHelper();
            IMailService mailService = new MailKitMailService(_configuration);
            IOtpAuthenticatorHelper otpAuthenticatorHelper = new OtpAuthenticatorHelper();

            _authService = new AuthService(_userOperationClaimRepository.Object, tokenHelper, _refreshTokenRepository.Object, emailAuthenticatorHelper, _userEmailAuthenticatorRepository.Object,mailService,otpAuthenticatorHelper, _userOtpAuthenticatorRepository.Object, _userTitleDefRepository.Object, _titleOperationClaimsRepository.Object);
        }

        [Fact]
        public async Task SuccessfullLoginTest()
        {
            LoginCommand command = new() { UserForLoginDto = new() { Email = "halit@kodlama.io", Password = "123456" }, IpAddress = "127.0.0.1" };
            LoginCommandHandler handler = new(_userRepository.Object,_authBusinessRules, _authService);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.NotNull(result.AccessToken.Token);
        }
        [Fact]
        public async Task JwtExpirationTimeTest()
        {
            LoginCommand command = new() { UserForLoginDto = new() { Email = "halit@kodlama.io", Password = "123456" }, IpAddress = "127.0.0.1" };
            LoginCommandHandler handler = new(_userRepository.Object, _authBusinessRules, _authService);
            var result = await handler.Handle(command, CancellationToken.None);
            var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
            bool tokenExpiresInTime = DateTime.UtcNow.AddMinutes(tokenOptions.AccessTokenExpiration + 1) > result.AccessToken.Expiration;
            Assert.True(tokenExpiresInTime,"İlgili access token geçerlilik süresi yanlış oluşturuldu.");
        }
    }
}
