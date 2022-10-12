using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Feature
{
    public Feature()
    {
    }
    
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<MediaInfo>? MediaInfos { get; set; }
}