using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks.Configurations
{
    public static class MockConfiguration
    {
        public static IConfiguration GetConfigurationMock()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                { "TokenOptions:Audience", "RentACar Users" },
                { "TokenOptions:Issuer", "RentACar" },
                { "TokenOptions:AccessTokenExpiration", "10" },
                { "TokenOptions:SecurityKey", "jL4N#QKR#U7wgYkA6D*%323UkSpfAH7c#M7h!Me@sSkgTtrBuU" },
                { "TokenOptions:RefreshTokenExpiration", "1440" },
                { "TokenOptions:RefreshTokenTTL", "180" },
                { "MailSettings:Server", "127.0.0.1" },

            };
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration);
            return config.Build();
        }
    }
}
