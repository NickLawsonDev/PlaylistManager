using Microsoft.EntityFrameworkCore;

namespace Core.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Playlist> Playlists { get; }
    DbSet<Song> Songs { get; }
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync();
}