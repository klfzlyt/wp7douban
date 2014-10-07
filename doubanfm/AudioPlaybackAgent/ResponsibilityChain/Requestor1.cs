
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace AudioPlaybackAgent.ResponsibilityChain
{
    class Requestor1<T> : RequestorBase<T>
    {
        public override T ProcessRequest(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(JToken.Parse(json)["song"].ToString());
            }
            catch
            {
                Debug.WriteLine("这个是在职责链中的该有的异常");
                return Successor.ProcessRequest(json);
            }
        }
    }
}
