using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Common.Guards;

public static class ContextGuards
{
    public static T Exists<T>(IQueryable<T> dbset, Guid id, string? message = null) where T : BaseEntity
    {
        if (dbset == null) throw new ArgumentNullException(nameof(dbset));
        GuidGuards.IsEmpty(id);

        var item = dbset.FirstOrDefault(x => x.Id == id);
        if (item == null) throw new NotFoundException(message ?? $"DbSet does not contain any entities with the id of {id}");
        return item;
    }

    public static async Task<T> ExistsAsync<T>(IQueryable<T> dbset, Guid id, string? message = null) where T : BaseEntity
    {
        if (dbset == null) throw new ArgumentNullException(nameof(dbset));
        GuidGuards.IsEmpty(id);

        var item = await dbset.FirstOrDefaultAsync(x => x.Id == id);
        if (item == null) throw new NotFoundException(message ?? $"DbSet does not contain any entities with the id of {id}");
        return item;
    }
}