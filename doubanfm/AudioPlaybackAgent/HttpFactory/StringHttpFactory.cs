
using AudioPlaybackAgent.HttpProduct;
namespace AudioPlaybackAgent.HttpFactory
{
    internal class StringHttpFactory : IHttpGet<string>
    {
        public HttpGetMethodBase<string> CreateHttpRequest()
        {
            return new HttpGetString();
        }
    }
}
