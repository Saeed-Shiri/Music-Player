

namespace MusicPlayer
{
    public interface ISongPlayer
    {
        //void AddTrack(Song song);
        void SetPlaybackStrategy(IPlaybackStrategy strategy);

        Task PlayAsync();
        void Pause();
        void Resume();
        void Stop();

        void NextTrack();
        void PreviousTrack();

    }
}
