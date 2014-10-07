using System;
using System.IO;
using System.IO.IsolatedStorage;
namespace AudioPlaybackAgent.Service
{
    internal class IsolatedStoreHelper
    {
         public bool AddOrUpdateValue(string Key, Object value)
        {

          
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                // If the key exists
                if (settings.Contains(Key))
                {

                    bool valueChanged = false;
                    // If the value has changed
                    if (settings[Key] != value)
                    {
                        // Store the new value
                        settings[Key] = value;
                        valueChanged = true;
                        settings.Save();
                        return valueChanged;
                    }
                    else
                    {
                        return valueChanged;
                    }
                }
                // Otherwise create the key.
                else
                {

                    bool valueChanged = false;
                    settings.Add(Key, value);
                    valueChanged = true;
                    settings.Save();
                    return valueChanged;
                }

            
        }
     static   public  string GetFileToString(string panthANDName)
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!storage.FileExists(panthANDName))
                {
                    return null;
                }
                using(IsolatedStorageFileStream fs=new IsolatedStorageFileStream(panthANDName,FileMode.Open,FileAccess.Read,storage))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {

                        return sr.ReadToEnd();
                    
                    }
                        
                
                }

            }
        
        
        
        
        
        
        
        
        
        }


      static  public  bool WriteOrUpdateStringToIsoStore(string PathANDName, string content)
        {
            try
            {
                using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream fs = storage.OpenFile(PathANDName, FileMode.Create, FileAccess.Write))
                    {

                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(content);
                            return true;
                        }
                    }

                }
            }
            catch
            {
                return false;
            }
           
        }

          public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
       {
           valueType value;
           IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
           // If the key exists, retrieve the value.
           if (settings.Contains(Key))
           {
               value = (valueType)settings[Key];
           }
           // Otherwise, use the default value.
           else
           {
               value = defaultValue;
           }

           return value;
       }


         public  void CopyToIsolatedStorage(string file_name,string path, Stream AudioStream)
        {
            ////要不要开一个线程来做这个存储？
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!storage.FileExists(path + file_name))
                {
                    using (IsolatedStorageFileStream file = storage.CreateFile(path + file_name))
                    {
                        int chunkSize = 4096;
                        byte[] bytes = new byte[chunkSize];
                        int byteCount;

                        while ((byteCount = AudioStream.Read(bytes, 0, chunkSize)) > 0)
                        {
                            file.Write(bytes, 0, byteCount);
                        }
                    }
                }
            }
        }


    }
}
