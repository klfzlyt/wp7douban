using System;
using System.Net;
using System.Windows.Media.Imaging;
using System.IO;
using System.Diagnostics;

namespace AudioPlaybackAgent.HttpProduct
{
    internal class HttpGetBitmapImage : HttpGetMethodBase<BitmapImage>
    {
        protected override BitmapImage WebResponse(IAsyncResult result)
        {
            try
            {
                var request = result.AsyncState as HttpWebRequest;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
                #region ignore
                if (response.Cookies != null)
                {
                    foreach (Cookie cookie in response.Cookies)
                    {
                        Debug.WriteLine(cookie.Value);
                    }
                }
                Debug.WriteLine(response.ContentType);
                Debug.WriteLine(response.StatusDescription);
                if (response.Headers["Set-Cookie"] != null)
                {
                    //setting may write
                    Debug.WriteLine(response.Headers["Set-Cookie"]);
                }
                #endregion
                Stream stream = response.GetResponseStream();
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.SetSource(stream);
                return bitmapimage;
            }
            catch
            {
                Debug.WriteLine("WEBERROR");
                return null;
            }
        }
    }
}
