using MusicPlayer;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

var songs = new List<Song>
        {
            new Song("🎵 song 1", 5),
            new Song("🎵 song 2", 7),
            new Song("🎵 song 3", 6),
        };

ISongPlayer player = new SongPlayer(songs);

//player.AddTrack(new Song("song 1", 5));
//player.AddTrack(new Song("song 2", 4));
//player.AddTrack(new Song("song 2", 6));

Console.WriteLine("commands: play, stop, pause, resume, next, prev, shuffle, repeatOne, repeatAll, sequential, exit");

while (true)
{
    Console.Write("> ");
    string command = Console.ReadLine()?.ToLower();

    switch (command)
    {
        case "play":
            await player.PlayAsync();
            break;
        case "stop":
            player.Stop();
            break;
        case "pause":
            player.Pause();
            break;
        case "resume":
            player.Resume();
            break;
        case "next":
            player.NextTrack();
            break;
        case "prev":
            player.PreviousTrack();
            break;
        case "shuffle":
            player.SetPlaybackStrategy(new ShufflePlayback());
            break;
        case "repeatone":
            player.SetPlaybackStrategy(new RepeatOnePlayback());
            break;
        case "repeatall":
            player.SetPlaybackStrategy(new RepeatAllPlayback());
            break;
        case "sequential":
            player.SetPlaybackStrategy(new SequentialPlayback());
            break;
        case "exit":
            player.Stop();
            return;
        default:
            Console.WriteLine("⛔ Invalid Command");
            break;
    }
}
