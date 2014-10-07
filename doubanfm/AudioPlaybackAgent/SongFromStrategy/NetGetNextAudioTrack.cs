
using AudioPlaybackAgent.Model;
using AudioPlaybackAgent.HttpFactory;
using System;
using Microsoft.Phone.BackgroundAudio;
using AudioPlaybackAgent.ResponsibilityChain;
namespace AudioPlaybackAgent.Strategy
{
    class NetGetNextAudioTrack : GetNextAudioTrack
    {
        public NetGetNextAudioTrack(Channel CurrentChannel, Song CurrentSong, User CurrentUser)
            : base(CurrentChannel, CurrentSong, CurrentUser)
        {

        }
        public NetGetNextAudioTrack(Channel CurrentChannel, Song CurrentSong)
            : base(CurrentChannel, CurrentSong)
        {

        }
        public NetGetNextAudioTrack(Song CurrentSong)
            : base(CurrentSong)
        {

        }
        public override void ChangeNextTrack()
        {
            //得知道当前的歌曲信息，频道信息，(用户信息)?
            //Url信息
            //这里的String要用反射

            IHttpGet<string> factory = new StringHttpFactory();//TODO
            string Url = FMresx.GetSongURL;
            factory.CreateHttpRequest().Get(Url).Subscribe(//TODO
                (result) =>
                {
                    //这里对ManagerResponsibilityChain有点依赖
                    Song nextsong = ManagerResponsibilityChain<Song>.Instance_Startrequestor.ProcessRequest(result);
                    var track = new AudioTrack(new Uri(nextsong.GetSongURL(), UriKind.Absolute), nextsong.title, nextsong.artist, nextsong.albumtitle, null);
                    OnHaveNextTrack(this, new NextTrackEventArgs(track));

                });

        }
    }
}
