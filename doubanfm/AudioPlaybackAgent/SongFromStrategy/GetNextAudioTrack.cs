
using AudioPlaybackAgent.Model;
using System;
using System.Diagnostics;
namespace AudioPlaybackAgent.Strategy
{
    /// <summary>
    /// 获得下一个Track的抽象策略
    /// </summary>
    abstract class GetNextAudioTrack
    {
        protected Song CurrentSong;
        protected Channel CurrentChannel;
        protected User CurrentUser;
        public event EventHandler<NextTrackEventArgs> HaveNextTrack;
        public abstract void ChangeNextTrack();
        protected GetNextAudioTrack(Channel CurrentChannel, Song CurrentSong)
        {
            this.CurrentChannel = CurrentChannel;
            this.CurrentSong = CurrentSong;

        }
        protected GetNextAudioTrack(Song CurrentSong)
        {

            this.CurrentSong = CurrentSong;

        }
        protected GetNextAudioTrack(Channel CurrentChannel, Song CurrentSong, User CurrentUser)
        {
            this.CurrentChannel = CurrentChannel;
            this.CurrentSong = CurrentSong;
            this.CurrentUser = CurrentUser;
        }


        protected void OnHaveNextTrack(object sender, NextTrackEventArgs e)
        {
            if (HaveNextTrack != null)
            {
                HaveNextTrack(sender, e);
            }
            else
            {
                Debug.WriteLine("事件没有注册呢");
            }
        }
    }
}
