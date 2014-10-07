
using System.Collections.Generic;
namespace AudioPlaybackAgent.ResponsibilityChain
{
     class ManagerResponsibilityChain<T>
    {
        static private RequestorBase<T> _startrequestor;
        static public RequestorBase<T> Instance_Startrequestor
        {
            get
            {
                if (_startrequestor == null)
                {
                    Inital();
                }
                return _startrequestor;
            }
        }
        private ManagerResponsibilityChain()
        {

        }

        static private void InsertARequestor(RequestorBase<T> InsertItem, List<RequestorBase<T>> RequestList)
        {
            RequestList.Insert(RequestList.Count - 1, InsertItem);
            InsertItem.SetSucessor(RequestList[RequestList.Count - 1]);
            RequestList[RequestList.Count - 3].SetSucessor(InsertItem);

        }


        static private void Inital()
        {
            List<RequestorBase<T>> RequestList = new List<RequestorBase<T>>();
            _startrequestor = new Requestor1<T>();
            var secondrequestor = new Requestor2<T>();
            var thridrequestor = new Requestor3<T>();
            RequestList.Add(_startrequestor);
            RequestList.Add(secondrequestor);
            RequestList.Add(thridrequestor);
            _startrequestor.SetSucessor(secondrequestor);
            secondrequestor.SetSucessor(thridrequestor);//requestor3 is the end 


          
        }

    }
}
