namespace Core.Domain.Common.Guards;

public static class GuidGuards
{
    public static void IsEmpty(Guid guid, string? message = null)
    {
        if (guid == Guid.Empty) throw new ArgumentNullException(message ?? nameof(guid));
    }
}