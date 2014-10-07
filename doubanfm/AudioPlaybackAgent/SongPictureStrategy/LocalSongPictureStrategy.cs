using System;
using System.Windows;
using AudioPlaybackAgent.Model;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;

namespace AudioPlaybackAgent.Strategy
{
  /// <summary>
  /// 本地歌曲图片策略类
  /// </summary>
        class LocalSongPictureStrategy :SongPictureStrategy
        {
        private  BitmapImage GetFileToBitmapImage(string Path)
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

        public LocalSongPictureStrategy(Song song)
        : base(song)
        { }
        public override BitmapImage SongPicture
        {
        get
        {
        return GetFileToBitmapImage(currentsong.GetSongPictureFullName());    
            
        }
        }
        }
    
}
