


using System.Collections.Generic;
using System.Threading;

namespace MusicPlayer
{
    public class SongPlayer : ISongPlayer
    {
        private readonly LinkedList<Song> _playList = new();
        private LinkedListNode<Song>? _currentSongNode;
        private Song? _currentSong;
        private bool _isPlaying;
        private bool _isPaused;
        private bool _isStoped;
        private bool _repeatAll;
        private bool _repeatOne;
        private CancellationTokenSource _cts;

        public SongPlayer(IEnumerable<Song> musics)
        {
            _playList = new LinkedList<Song>(musics);
            _currentSongNode = _playList?.First;
            _currentSong = _currentSongNode?.Value;
            _cts = new CancellationTokenSource();
        }
        public async Task Next()
        {
            if (_repeatOne)
            {
                _currentSongNode = _currentSongNode?.Next ?? _playList.First;
            }
            if (_repeatAll)
            {
                _currentSongNode = _currentSongNode?.Next ?? _playList.First;
            }
            
            
        }

        public async Task Pause()
        {
            
            await _cts.CancelAsync();

            var currentSong = _currentSongNode?.Value;
            Console.WriteLine($"{currentSong?.Title} paused");
            _isPaused = true;
            _isPlaying = false;
        }

        public async Task Play()
        {
            if (_currentSong == null)
            {
                Console.WriteLine($"Playlist is empty");
                return;
            }


            var currentSong = _currentSongNode?.Value;

            Console.WriteLine($"Playing {currentSong?.Title}");
            _isPlaying = true;

            try
            {
                await Task.Delay(currentSong.Duration * 1000, _cts.Token);
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine($"Playing is paused");
            }
            finally
            {
                _cts.Dispose();
            }


        }

        public async Task Previous()
        {
            await Stop();

            if (_repeatAll)
            {
                _currentSongNode = _currentSongNode?.Previous ?? _playList.Last;
            }

            await Play();
        }

        public Task RepeatAll()
        {
            _repeatAll = true;
            return Task.CompletedTask;
        }

        public Task RepeatOne()
        {
            _repeatOne = true;
            _repeatAll = false;
            return Task.CompletedTask;
        }

        public Task Shuffle()
        {
            throw new NotImplementedException();
        }

        public async Task Stop()
        {
            
            await _cts.CancelAsync();

            var currentSong = _currentSongNode?.Value;
            Console.WriteLine($"{currentSong?.Title} stoped");
            _isPaused = false;
            _isPlaying = false;
            _isStoped = true;
        }
    }
}
