using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 豆瓣电台.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}
