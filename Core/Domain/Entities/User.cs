namespace Core.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public IEnumerable<Playlist> Playlists { get; set; }

    public User(string firstName, string lastName, string email, string password, IEnumerable<Playlist> playlists)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Playlists = playlists;
    }
}