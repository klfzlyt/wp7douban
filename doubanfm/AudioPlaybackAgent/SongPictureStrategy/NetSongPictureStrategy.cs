using System;
using AudioPlaybackAgent.Model;
using System.Windows.Media.Imaging;

namespace AudioPlaybackAgent.Strategy
{
   /// <summary>
   /// 网络歌曲图片策略类
   /// </summary>
    class NetSongPictureStrategy :SongPictureStrategy
      {
            public NetSongPictureStrategy(Song song)
            : base(song)
            {
            
            }

        public override BitmapImage SongPicture
        {
            get { return new BitmapImage(new Uri(currentsong.GetPictureURL(), UriKind.Absolute)); }
        } 
    }
}
