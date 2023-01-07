namespace Core.Domain.Entities;

public record Song(string Name, double Length, string Lyrics) : BaseEntity;