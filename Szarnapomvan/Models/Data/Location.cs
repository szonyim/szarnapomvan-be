using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Szarnapomvan.Models.Data;

[Table("Locations")]
public class Location
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    
    [JsonIgnore]
    public virtual ICollection<Post> Posts { get; set; } = default!;
}