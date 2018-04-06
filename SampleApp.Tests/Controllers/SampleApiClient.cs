using System.Net.Http;
using System.Threading.Tasks;
using SampleApp.Tests.Model;
using WordPressPCL.Models;

namespace SampleApp.Tests.Controllers
{
    public class SampleApiClient : WpApplicationApiClient<SampleApiClient>
    {
        protected override string ApplicationApiUri => $"{BaseApplicationUri}wp-json";

        private const string SampleCommentsEndpoint = "sampleapp/v1/comments";

        public SampleApiClient(DesiredConfiguration desiredConfiguration) : base(desiredConfiguration)
        {
        }

        public async Task<Comment> AddCommentToPostId(string url, string content)
        {
            return await WordPressClient.CustomRequest.Create<Comment, Comment>(SampleCommentsEndpoint, new SampleComment
            {
                Content = new Content(content),
                Uri = url,
            });
        }

        public async Task<HttpResponseMessage> DeleteCommentToPostId(int commentId)
        {
            return await WordPressClient.CustomRequest.Delete($"{SampleCommentsEndpoint}/{commentId}");
        }

        public async Task<bool> DeleteCommentToPostIdWorkaround(int commentId)
        {
            return await WordPressClient.CustomRequest.DeleteWorkaround($"{SampleCommentsEndpoint}/{commentId}");
        }
    }
}