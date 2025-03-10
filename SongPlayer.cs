


namespace MusicPlayer
{
    public class SongPlayer : ISongPlayer
    {
        private readonly LinkedList<Song> _musics;
        private Song? _currentSong;
        private readonly bool _isPlaying;
        private readonly bool _isPaused;

        public SongPlayer(LinkedList<Song> musics)
        {
            _musics = musics;
            _currentSong = _musics.First?.Value;
        }
        public Task<LinkedListNode<Song>> Next()
        {
            throw new NotImplementedException();
        }

        public Task Pause()
        {
            throw new NotImplementedException();
        }

        public async Task Play()
        {
            if (_currentSong == null)
            {
                Console.WriteLine($"Playlist is empty");
                return;
            }

            if (_isPlaying)
                return;

            Console.WriteLine($"Playing {_currentSong.Title}");
            await Task.Delay(_currentSong.Duration*1000);
            await Task.CompletedTask;
        }

        public Task<LinkedListNode<Song>> Previous()
        {
            throw new NotImplementedException();
        }

        public Task RepeatAll()
        {
            throw new NotImplementedException();
        }

        public Task RepeatOne(Song track)
        {
            throw new NotImplementedException();
        }

        public Task Shuffle()
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
