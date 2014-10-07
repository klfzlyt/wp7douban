
using AudioPlaybackAgent.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.BackgroundAudio;
using System;
namespace AudioPlaybackAgent.Strategy
{
    class LocalGetNextAudioTrack : GetNextAudioTrack//类内高内聚
    {
        private IList<Song> playList;
        /// <summary>
        /// 设置或获得Local的playList
        /// </summary>
        public IList<Song> PlayList
        {
            get { return playList; }
            set
            {
                playList = value;
                playListsOfSongNames = playList.Select(
                  (song) =>
                  {
                      var chararray = song.title.ToCharArray();
                      return new string(chararray, 0, chararray.Length);
                  }).ToList();
            }
        }
        private IList<string> playListsOfSongNames;
        public LocalGetNextAudioTrack(Channel CurrentChannel, Song CurrentSong, User CurrentUser, IList<Song> playlist)   //注入PlayLists
            : base(CurrentChannel, CurrentSong, CurrentUser)
        {
            playList = playlist;
            playListsOfSongNames = playlist.Select(
               (song) =>
               {
                   var chararray = song.title.ToCharArray();
                   return new string(chararray, 0, chararray.Length);
               }).ToList();
        }
        public LocalGetNextAudioTrack(Channel CurrentChannel, Song CurrentSong, IList<Song> playlist)   //注入PlayLists
            : base(CurrentChannel, CurrentSong)
        {
            playList = playlist;
            playListsOfSongNames = playlist.Select(
              (song) =>
              {
                  var chararray = song.title.ToCharArray();
                  return new string(chararray, 0, chararray.Length);
              }).ToList();
        }
        public LocalGetNextAudioTrack(Song CurrentSong, IList<Song> playlist)   //注入PlayLists
            : base(CurrentSong)
        {
            playList = playlist;
            playListsOfSongNames = playlist.Select(
              (song) =>
              {
                  var chararray = song.title.ToCharArray();
                  return new string(chararray, 0, chararray.Length);
              }).ToList();
        }

        public override void ChangeNextTrack()
        {
            if (!playListsOfSongNames.Contains(CurrentSong.title))
            {
                //播放第0首
                var nextsong = playList[0];
                var track = new AudioTrack(new Uri(nextsong.GetSongFullName(), UriKind.Relative), nextsong.title, nextsong.artist, nextsong.albumtitle, null);
                OnHaveNextTrack(this, new NextTrackEventArgs(track));
            }
            else
            {
                //播放当前首的下一首
                var nextsong = GetPlaylistNextSong(CurrentSong);
                var track = new AudioTrack(new Uri(nextsong.GetSongFullName(), UriKind.Relative), nextsong.title, nextsong.artist, nextsong.albumtitle, null);
                OnHaveNextTrack(this, new NextTrackEventArgs(track));
            }
        }
        private Song GetPlaylistNextSong(Song song)
        {
            var num = playListsOfSongNames.IndexOf(song.title) + 1;
            if (!(num == playListsOfSongNames.Count))
            {
                //不是最后一首歌
                return playList[num];
            }
            else
            {
                return playList[0];
            }
        }
    }
  
}
