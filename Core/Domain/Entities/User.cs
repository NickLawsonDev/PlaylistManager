namespace Core.Domain.Entities;

public record User(string Password, string FirstName, string LastName, string Email, IEnumerable<Playlist> Playlists) : BaseEntity;