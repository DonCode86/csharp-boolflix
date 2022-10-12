public class Pegi
{
    public Pegi()
    {
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Film> Films { get; set; }
    public List<TVSeries> TVSeries { get; set; }
}