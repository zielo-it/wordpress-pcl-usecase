using System.Threading.Tasks;
using NUnit.Framework;
using SampleApp.Tests.Configuration;

namespace SampleApp.Tests.Tests
{
    [TestFixture]
    [Category("API")]
    public class Tests : TestFixtureBase
    {
        private const string CommentUri = "SampleURI";

        [Test]
        public async Task DeleteCommentByUriNotWorking()
        {
            var content = $"Comment to delete {Random.Next(0, 1000)}";

            var lastCommentId = (await SampleApiClient.AddCommentToPostId(CommentUri, content)).Id;

            Assert.IsTrue((await SampleApiClient.DeleteCommentToPostId(lastCommentId)).IsSuccessStatusCode);
        }

        [Test]
        public async Task DeleteCommentByUri()
        {
            var content = $"Comment to delete {Random.Next(0, 1000)}";

            var lastCommentId = (await SampleApiClient.AddCommentToPostId(CommentUri, content)).Id;

            Assert.IsTrue(await SampleApiClient.DeleteCommentToPostIdWorkaround(lastCommentId));
        }
    }
}