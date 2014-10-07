using System;
using System.ComponentModel;
namespace AudioPlaybackAgent.Model
{
    public class Channel:INotifyPropertyChanged
    {

        private string id;

        public string ChannelId
        {
            get { return id; }
            set { id = value; }
        }


        private Uri imageSource;

        public Uri ChannelImageSource
        {
            get { return imageSource; }
            set
            { 
                 imageSource = value;
                 if (PropertyChanged != null)
                     PropertyChanged(this, new PropertyChangedEventArgs("ChannelImageSource"));
               
            
            }
        }
        private Uri imageThumbnailSource;

        public Uri ChannelImageThumbnailSource
        {
            get { return imageThumbnailSource; }
            set { imageThumbnailSource = value; }
        }
        private string name;

        public string ChannelName
        {
            get { return name; }
            set { name = value; }
        }
        private string intro;

        public string ChannelIntro
        {
            get { return intro; }
            set 
            { intro = value;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("ChannelIntro"));
            }
        }
        private string group;

        public string ChannelGroup
        {
            get { return group; }
            set { group = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
