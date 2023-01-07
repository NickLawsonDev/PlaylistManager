namespace Core.Domain.Entities;

public class Playlist : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Song> Songs { get; set; }
    public User User { get; set; }

    public Playlist(string name, User user, IEnumerable<Song> songs)
    {
        Name = name;
        User = user;
        Songs = songs;
    }
}