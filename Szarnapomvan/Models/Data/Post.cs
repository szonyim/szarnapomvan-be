using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Szarnapomvan.Enums;

namespace Szarnapomvan.Models.Data;

[Table("Posts")]
public class Post
{
  [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public long Id { get; set; }
  
  public BadLevel BadLevel { get; set; }

  [Required, MaxLength(255)]
  public string CreatedBy { get; set; } = default!;
  
  [DataType(DataType.DateTime)]
  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}")]
  public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
  
  [Required, MaxLength(2000)]
  public string Content { get; set; } = default!;
  public virtual Location Location { get; set; } = default!;
}