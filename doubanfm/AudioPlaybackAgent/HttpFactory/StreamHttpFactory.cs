
using AudioPlaybackAgent.HttpProduct;
using System.IO;
namespace AudioPlaybackAgent.HttpFactory
{
    internal class StreamHttpFactory : IHttpGet<Stream>
    {

        public HttpGetMethodBase<Stream> CreateHttpRequest()
        {
            return new HttpGetStream();
        }
    }
}
