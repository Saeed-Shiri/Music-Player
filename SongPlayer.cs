


using System.Collections.Generic;
using System.Threading;

namespace MusicPlayer
{
    public class SongPlayer : ISongPlayer
    {
        private readonly LinkedList<Song> _playList = new();
        private LinkedListNode<Song>? _currentSongNode;
        private IPlaybackStrategy _playbackStrategy = new SequentialPlayback();
        private bool _isPaused;
        private CancellationTokenSource? _cts;

        public SongPlayer(IEnumerable<Song> songs)
        {
            _playList = new LinkedList<Song>(songs);
            _playbackStrategy = new SequentialPlayback();
            _currentSongNode = _playList.First;
        }

        public void SetPlaybackStrategy(IPlaybackStrategy strategy)
        {
            _playbackStrategy = strategy;
        }

        public async Task PlayAsync()
        {
            if (_currentSongNode == null)
            {
                Console.WriteLine("🎵 لیست آهنگ‌ها خالی است.");
                return;
            }

            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            while (_currentSongNode != null)
            {
                Console.WriteLine($"▶️ در حال پخش: {_currentSongNode.Value.Title}");

                for (int i = 0; i < _currentSongNode.Value.DurationInSeconds; i++)
                {
                    if (token.IsCancellationRequested) return;
                    if (_isPaused)
                    {
                        Console.WriteLine("⏸ پخش متوقف شد.");
                        await Task.Delay(Timeout.Infinite, token);
                    }

                    Console.Write(".");
                    await Task.Delay(1000, token); 
                }

                _currentSongNode = _playbackStrategy.GetNextTrack(_currentSongNode, _playList);
            }
        }

        public void Stop()
        {
            _cts?.Cancel();
            Console.WriteLine("⏹ پخش متوقف شد.");
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            if (_isPaused)
            {
                _isPaused = false;
                _cts?.Cancel();
                _cts = new CancellationTokenSource();
                Task.Run(async () =>
                {
                    try
                    {
                        await PlayAsync();
                    }
                    catch (TaskCanceledException) { }
                });
            }
        }

        public void NextTrack()
        {
            _cts?.Cancel();
            _currentSongNode = _playbackStrategy.GetNextTrack(_currentSongNode, _playList);
            Task.Run(() => PlayAsync());
        }

        public void PreviousTrack()
        {
            _cts?.Cancel();
            _currentSongNode = _currentSongNode?.Previous ?? _playList.Last;
            Task.Run(() => PlayAsync());
        }
    }
}
