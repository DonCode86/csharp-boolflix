using csharp_boolflix.Models;

public class TVSeries : MediaContent
{
    public MediaInfo MediaInfo { get; set; }
    public int SeasonCount { get; set; }

    public List<Episode> Episodes { get; set; }

}
