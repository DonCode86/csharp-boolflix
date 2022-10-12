using csharp_boolflix.Models;

public class Film : MediaContent
{
    public Film()
    {
    }
    public MediaInfo MediaInfo { get; set; }

    public int Duration { get; set; }

    public int PegiId { get; set; }

    public Pegi Pegi { get; set; }
}
