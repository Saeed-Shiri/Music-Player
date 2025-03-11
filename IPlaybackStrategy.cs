

namespace MusicPlayer
{
    public interface IPlaybackStrategy
    {
        public LinkedListNode<Song>? GetNextTrack(LinkedListNode<Song>? currentTrack, LinkedList<Song> playlist);
    }

    public class SequentialPlayback : IPlaybackStrategy
    {
        public LinkedListNode<Song>? GetNextTrack(LinkedListNode<Song>? currentTrack, LinkedList<Song> playlist) => currentTrack?.Next;
    }

    public class ShufflePlayback : IPlaybackStrategy
    {
        private readonly Random _random = new();
        public LinkedListNode<Song>? GetNextTrack(LinkedListNode<Song>? currentTrack, LinkedList<Song> playlist)
        {
            if(playlist.Count == 0)
                return null;

            int randomNumber = _random.Next(playlist.Count);
            LinkedListNode<Song>? nextTrack = playlist.First;

            for (int i = 0; i < randomNumber; i++)
            {
                nextTrack = nextTrack?.Next;
            }

            return nextTrack;
        }
    }

    public class RepeatOnePlayback : IPlaybackStrategy
    {
        public LinkedListNode<Song>? GetNextTrack(LinkedListNode<Song>? currentTrack, LinkedList<Song> playlist) => currentTrack;
    }

    public class RepeatAllPlayback : IPlaybackStrategy
    {
        public LinkedListNode<Song>? GetNextTrack(LinkedListNode<Song>? currentTrack, LinkedList<Song> playlist) =>
            currentTrack?.Next ?? playlist.First;
    }

}
