namespace Core.Domain.Entities;

public class Song : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double Length { get; set; }
    public string Lyrics { get; set; } = string.Empty;

    public Song(string name, double length, string lyrics)
    {
        Name = name;
        Length = length;
        Lyrics = lyrics;
    }
}