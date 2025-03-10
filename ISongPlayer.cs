

namespace MusicPlayer
{
    public interface ISongPlayer
    {
        Task Play();
        Task Pause();
        Task Stop();

        Task<LinkedListNode<Song>> Next();
        Task<LinkedListNode<Song>> Previous();
        Task Shuffle();
        Task RepeatOne(Song track);
        Task RepeatAll();
    }
}
