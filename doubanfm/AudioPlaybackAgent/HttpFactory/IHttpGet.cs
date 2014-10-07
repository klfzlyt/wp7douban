using AudioPlaybackAgent.HttpProduct;
namespace AudioPlaybackAgent.HttpFactory
{
    interface IHttpGet<T>
    {
        HttpGetMethodBase<T> CreateHttpRequest();
    }
}
