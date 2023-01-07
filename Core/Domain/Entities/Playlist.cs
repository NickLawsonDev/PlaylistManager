namespace Core.Domain.Entities;

public record Playlist(string Name, IEnumerable<Song> Songs, User User) : BaseEntity;