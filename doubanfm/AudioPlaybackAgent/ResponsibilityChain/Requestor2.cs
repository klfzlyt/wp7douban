
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
namespace AudioPlaybackAgent.ResponsibilityChain
{
    class Requestor2<T> : RequestorBase<T>
    {
        public override T ProcessRequest(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(JToken.Parse(json)["song"][0].ToString());
            }
            catch
            {
                Debug.WriteLine("这个是在职责链中的该有的异常");
                return Successor.ProcessRequest(json);
            }
        }
    }
}
