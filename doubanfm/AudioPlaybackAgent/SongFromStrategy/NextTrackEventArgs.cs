using System;
using Microsoft.Phone.BackgroundAudio;

namespace AudioPlaybackAgent.Strategy
{
    class NextTrackEventArgs : EventArgs
    {
        public NextTrackEventArgs(AudioTrack track)
        {
            _track = track;
        }
        private AudioTrack _track;

        public AudioTrack Track
        {
            get { return _track; }
            set { _track = value; }
        }
    }
}
