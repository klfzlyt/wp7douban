using System;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Media.Imaging;
using AudioPlaybackAgent.Service;
using AudioPlaybackAgent.Strategy;
namespace AudioPlaybackAgent.Model
{
    public class Song
    {
     
        public Song() {}
        public string url { set; get; }
        public string picture { set; get; }
        public string title { set; get; }
        public string length { set; get; }
        public string album { get; set; }
        public string  ssid { get; set; }
        public string artist { get; set; }
        public string company { get; set; }
        public string albumtitle { set; get; }
        public string genre { set; get; }
        public bool like { set; get; }
        public string sid { set; get; }
        public string songlists_count { set; get; }
        public string public_time { set; get; }

     
     
    
        public BitmapImage SongPicture
        {
           
            get 
            {
                string stringbuder = "AudioPlaybackAgent.Strategy.";
                 stringbuder+=IsolatedStoreHelper.GetFileToString(FMresx.SongPictureStrategy);
                object[] parameter=new object[1];
                parameter[0] = this;
                SongPictureStrategy strategy = (SongPictureStrategy)Activator.CreateInstance(System.Type.GetType(stringbuder), parameter);
                return strategy.SongPicture;
            }

        }
        public BitmapImage LocalSongBitmapImage
        {
            get
            {
                try
                {
                    return GetFileToBitmapImage(this.GetSongPictureFullName());
                }
                catch (Exception)
                {
                    return null;
               
                }
              
            }        
        }


        //public double rating_avg { get; set; }
        //public string  subtype { get; set; }
        //public string public_time { get; set; }
        //public int songlists_count { get; set; }
        //public int sid { get; set;}
        //public int aid { get; set; }
        //public string sha256 { get; set; }
        //public string kbps { get; set; }
        //public string albumtitle { get; set; }
        //public bool like { get; set; }

        #region 公共方法
        /// <summary>
        ///返回歌曲的http地址
        /// </summary>
      public string GetSongURL()
      {
      return url;
      
      }
        /// <summary>
        /// 返回歌曲的http图片地址
        /// </summary>
        /// <returns></returns>
      public string GetPictureURL()
      {
          return picture;
      
      }
      public string GetSongName()
      {
          return title;
      }

        public string GetSonglength()
        {
            return length;
        }

        /// <summary>
        /// 获得带后缀的歌曲信息如：XXX.MP3 or XXX.MP4
        /// </summary>
        /// <returns></returns>
        public string  GetSongFullName()
        {
      
           return  title+url.Substring(url.LastIndexOf("."));
        
        }

        public string GetSongPictureFullName()
        {
            return title + picture.Substring(picture.LastIndexOf("."));

        }
        #endregion
        #region 私有方法
        private BitmapImage GetFileToBitmapImage(string Path)
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {

                if (storage.FileExists(Path))
                {
                    using (IsolatedStorageFileStream filestream = storage.OpenFile(Path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        try
                        {
                            BitmapImage image = new BitmapImage();////这个是从Local 来的
                            image.SetSource(filestream);
                            return image;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(" image Failed " + e.Message);
                            return null;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
        }


        #endregion
    }
}
