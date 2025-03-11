

namespace MusicPlayer
{
    public class Song
    {
        public Song(string title, int durationInSeconds)
        {
            Title = title;
            DurationInSeconds = durationInSeconds;
        }
        public int DurationInSeconds { get; set; }
        public string Title { get; set; }
    }
}
