

namespace MusicPlayer
{
    public interface IMusicPlayer
    {
        Task Play();
        Task Pause();
        Task Stop();

        Task<LinkedListNode<Music>> Next();
        Task<LinkedListNode<Music>> Previous();
        Task Shuffle();
        Task RepeatOne(Music track);
        Task RepeatAll();
    }
}
