using System.Windows.Media.Imaging;
using AudioPlaybackAgent.HttpProduct;

namespace AudioPlaybackAgent.HttpFactory
{
    internal class BitmapImageHttpFactory : IHttpGet<BitmapImage>
    {
        public HttpGetMethodBase<BitmapImage> CreateHttpRequest()
        {
            return new HttpGetBitmapImage();
        }
    }
}
