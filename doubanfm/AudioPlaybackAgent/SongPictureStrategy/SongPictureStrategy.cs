using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using AudioPlaybackAgent.Model;
using System.Windows.Media.Imaging;

namespace AudioPlaybackAgent.Strategy
{
    /// <summary>
    /// 为歌曲图片来源提供抽象类
    /// </summary>
        abstract class SongPictureStrategy
        {
            protected Song currentsong;
            protected SongPictureStrategy(Song song)
            {
                currentsong = song;
            }
         /// <summary>
         /// 只读获取歌曲图片
         /// </summary>
            public abstract BitmapImage SongPicture { get; }
        }
    
}
