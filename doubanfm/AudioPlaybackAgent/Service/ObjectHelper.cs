
using AudioPlaybackAgent.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
namespace AudioPlaybackAgent.Service
{
    /// <summary>
    /// 这个类跟CurrentXXX.dat相依赖
    /// </summary>
    internal class ObjectHelper
    {
        static private Dictionary<Type, string> dictionary = new Dictionary<Type, string>();
        static ObjectHelper()
        {
            dictionary.Add(typeof(Song), FMresx.CurrentSong);
            dictionary.Add(typeof(Channel), FMresx.CurrentChannel);
            dictionary.Add(typeof(User), FMresx.CurrentUser);
        }

        /// <summary>
        /// 获得本地文件CurrentXXXX.dat的对象表示
        /// </summary>
        /// <returns></returns>
        static public T GetLocalCurrentdat<T>() where T:class
        {
            try
            {

                var str = IsolatedStoreHelper.GetFileToString(dictionary[typeof(T)]);
                return JsonConvert.DeserializeObject<T>(str);
                
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 设置对象到CurrentXXX.dat文件中
        /// </summary>
        static public void SetObjectToLocal<T>(T item) where T:class
        {
            var str = JsonConvert.SerializeObject(item);
            IsolatedStoreHelper.WriteOrUpdateStringToIsoStore(dictionary[typeof(T)], str);
        }
    }
}
