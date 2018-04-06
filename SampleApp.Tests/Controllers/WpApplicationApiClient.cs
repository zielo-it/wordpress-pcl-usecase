using System;
using System.Net;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Models;

namespace SampleApp.Tests.Controllers
{
    public abstract class WpApplicationApiClient<T> where T : class
    {
        private readonly DesiredConfiguration _desiredConfiguration;

        protected WordPressClient WordPressClient;

        protected Uri BaseApplicationUri => new Uri(_desiredConfiguration.BaseApplicationUrl);

        protected abstract string ApplicationApiUri { get; }

        protected WpApplicationApiClient(DesiredConfiguration desiredConfiguration)
        {
            _desiredConfiguration = desiredConfiguration;
        }

        public virtual async Task<T> InitializeAsync()
        {
            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
            WordPressClient = new WordPressClient(ApplicationApiUri) { AuthMethod = AuthMethod.JWT };
            await WordPressClient.RequestJWToken(_desiredConfiguration.Username, _desiredConfiguration.Password);

            return this as T;
        }
    }

    public class DesiredConfiguration
    {
        public string BaseApplicationUrl { get; }
        public string Username { get; }
        public string Password { get; }

        public DesiredConfiguration(string baseApplicationUrl, string userName, string passWord)
        {
            BaseApplicationUrl = baseApplicationUrl;
            Username = userName;
            Password = passWord;
        }
    }
}