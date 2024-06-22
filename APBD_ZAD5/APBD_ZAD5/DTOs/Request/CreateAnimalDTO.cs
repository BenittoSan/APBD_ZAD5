using System.ComponentModel.DataAnnotations;

namespace APBD_ZAD5.DTOs.Request;

public class CreateAnimalDTO
{
    [Required]
    [MaxLength(200)]
    public String Name  { get; set; }
    [Required]
    [MaxLength(200)]
    public String? Description { get; set; }
    [Required]
    [MaxLength(200)]
    public String Category { get; set; }
    [Required]
    [MaxLength(200)]
    public String Area { get; set; }
}