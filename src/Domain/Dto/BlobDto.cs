namespace Domain.Dto;
public class BlobDto
{
    public string Uri { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public Stream Content { get; set; }
}