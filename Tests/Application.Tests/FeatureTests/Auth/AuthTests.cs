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

            IConfiguration configuration = MockConfiguration.GetConfigurationMock();

            ITokenHelper tokenHelper = new JwtHelper(configuration);
            IEmailAuthenticatorHelper emailAuthenticatorHelper = new EmailAuthenticatorHelper();
            IMailService mailService = new MailKitMailService(configuration);
            IOtpAuthenticatorHelper otpAuthenticatorHelper = new OtpAuthenticatorHelper();

            _authService = new AuthService(_userOperationClaimRepository.Object, tokenHelper, _refreshTokenRepository.Object, emailAuthenticatorHelper, _userEmailAuthenticatorRepository.Object,mailService,otpAuthenticatorHelper, _userOtpAuthenticatorRepository.Object, _userTitleDefRepository.Object, _titleOperationClaimsRepository.Object);
        }
    }
}
