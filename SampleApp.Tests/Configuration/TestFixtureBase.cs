using System;
using System.Configuration;
using System.Threading.Tasks;
using NUnit.Framework;
using SampleApp.Tests.Controllers;

namespace SampleApp.Tests.Configuration
{
    public class TestFixtureBase
    {
        protected SampleApiClient SampleApiClient;
        protected static readonly Random Random = new Random();

        [SetUp]
        public async Task SetUpAsync()
        {
            SampleApiClient = await new SampleApiClient(new DesiredConfiguration(ConfigurationManager.AppSettings["baseUrl"], "username", "password")).InitializeAsync();
        }
    }
}