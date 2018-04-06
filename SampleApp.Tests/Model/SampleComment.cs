using Newtonsoft.Json;
using WordPressPCL.Models;

namespace SampleApp.Tests.Model
{
    public class SampleComment : Comment
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
        public int Parent { get; set; }
    }
}