namespace APBD_ZAD5.DTOs.Response;

public class GetAnimalsDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null;
    public string? Description { get; set; }
    public string Category { get; set; } = null;
    public string Area { get; set; }
}