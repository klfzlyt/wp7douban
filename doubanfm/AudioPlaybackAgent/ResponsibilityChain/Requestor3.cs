
using System.Diagnostics;
namespace AudioPlaybackAgent.ResponsibilityChain
{
    class Requestor3<T> : RequestorBase<T>
    {
        public override T ProcessRequest(string json)
        {
            Debug.WriteLine("在职责链中没有能找到处理请求的方法，返回Default");
            return default(T);
            //NO Chain 继续下去了
        }
    }
}
