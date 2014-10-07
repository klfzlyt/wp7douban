using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace AudioPlaybackAgent.HttpProduct
{
    internal class HttpGetString : HttpGetMethodBase<string>
    {
        protected override string WebResponse(IAsyncResult result)
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
                using (StreamReader sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }
            catch
            {
                Debug.WriteLine("WEBERROR");
                return null;
            }
        }
    }
}
