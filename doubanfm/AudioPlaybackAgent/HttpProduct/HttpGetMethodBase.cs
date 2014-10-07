using System;
using System.Net;
using System.Reactive.Linq;

namespace AudioPlaybackAgent.HttpProduct
{
    /// <summary>
    /// HttpGet请求的抽象基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class HttpGetMethodBase<T>
    {
        internal  IObservable<T> Get(string Url)
        {
         
            var func = Observable.FromAsyncPattern<HttpWebRequest, T>(Webrequest, WebResponse);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
            return func(request);
        }
        private IAsyncResult Webrequest(HttpWebRequest request, AsyncCallback callbcak, object ob)
        {
            return request.BeginGetResponse(callbcak, request);
        }

        //发的请求用的是父类的get,WebResponse用的是子类的
        protected abstract T WebResponse(IAsyncResult result);
    }
}
