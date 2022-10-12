public class MediaInfo
{
    public int Id { get; set; }
    public string Year { get; set; }
    public bool IsNew { get; set; }
    public int? FilmId { get; set; }
    public Film? Film { get; set; }

    public List<Actor> Cast { get; set; }
    public List<Genre> Generes { get; set; }
    public List<Feature> Features { get; set; }
    public int? TvSeriesId { get; set; }
    public TVSeries? tVSeries { get; set; }
}
