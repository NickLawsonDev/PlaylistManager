using Microsoft.EntityFrameworkCore;

namespace Core.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Playlist> Playlists { get; }
    DbSet<Song> Songs { get; }

    Task<int> SaveChangesAsync();
}