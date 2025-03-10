

namespace MusicPlayer
{
    public class Song
    {
        public Song(string title, int duration)
        {
            Title = title;
            Duration = duration;
        }
        public int Duration { get; set; }
        public string Title { get; set; }
    }
}
