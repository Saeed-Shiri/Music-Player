

namespace MusicPlayer
{
    public interface ISongPlayer
    {
        Task Play();
        Task Pause();
        Task Stop();

        Task Next();
        Task Previous();
        Task Shuffle();
        Task RepeatOne();
        Task RepeatAll();
    }
}
