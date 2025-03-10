using MusicPlayer;

List<Song> playlist = new()
        {
            new Song("song 1", 5),
            new Song("song 2", 4),
            new Song("song 3", 6),
        };

ISongPlayer player = new SongPlayer(playlist);

Console.WriteLine("commands: play, stop, pause, resume, next, prev, shuffle, repeatOne, repeatAll, sequential, exit");

while (true)
{
    Console.Write("> ");
    string command = Console.ReadLine()?.ToLower();

    switch (command)
    {
        case "play":
            await player.Play();
            break;
        case "stop":
            await player.Stop();
            break;
        case "pause":
            await player.Pause();
            break;
        //case "resume":
        //    await player.ResumeAsync();
        //    break;
        case "next":
            await player.Next();
            break;
        case "prev":
            await player.Previous();
            break;
        //case "shuffle":
        //    player.SetPlaybackStrategy(new ShufflePlayback());
        //    break;
        case "repeatone":
            await player.RepeatOne();
            break;
        case "repeatall":
            await player.RepeatAll();
            break;
        //case "sequential":
        //    player.SetPlaybackStrategy(new SequentialPlayback());
        //    break;
        case "exit":
            await player.Stop();
            return;
        default:
            Console.WriteLine("⛔ دستور نامعتبر!");
            break;
    }
}
