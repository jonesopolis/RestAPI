using AG.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.IO;

namespace AG.Api.Tests
{
    public abstract class BaseTest
    {
        protected void SetupTextFixture(Action<IServiceCollection> action)
        {
            var builder = new WebHostBuilder()
                   .UseContentRoot(GetContentRootPath())
                   .UseEnvironment("Test")
                   .ConfigureTestServices(action)
                   .UseStartup<Startup>();

            var testServer = new TestServer(builder);

            Settings.BaseUrl = "http://test/";
            Settings.Client = testServer.CreateClient();
        }

        private string GetContentRootPath()
        {
            var testProjectPath = PlatformServices.Default.Application.ApplicationBasePath;
            var relativePathToHostProject = @"..\..\..\..\AG.Web";
            return Path.Combine(testProjectPath, relativePathToHostProject);
        }
    }
}
