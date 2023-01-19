using System.ComponentModel.DataAnnotations;
using Szarnapomvan.Enums;

namespace Szarnapomvan.Models.Request;

public class CreatePostRequest
{
    [Required]
    public string CreatedBy { get; set; } = default!;

    public BadLevel BadLevel { get; set; } = BadLevel.Bad;
    
    [Required] 
    public string Content { get; set; } = default!;
    
    [Required]
    public long LocationId { get; set; }
}