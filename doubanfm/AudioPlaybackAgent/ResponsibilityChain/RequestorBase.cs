
namespace AudioPlaybackAgent.ResponsibilityChain
{
    abstract class RequestorBase<T>
    {
        protected RequestorBase<T> Successor;
        internal void SetSucessor(RequestorBase<T> suc)
        {
            Successor = suc;
        }
        public abstract T ProcessRequest(string json);//抽象不依赖于具体，抽象依赖于抽象
    }
}
