using System.ComponentModel.DataAnnotations;

namespace weges_v2.ApiModel.Models;

public abstract class Entity<KType> : IEntity<KType>
{
    [Required]
    public KType Id { get; set; }
    public DateTime Created { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime Modified { get; private set; }
    public string ModifiedBy { get; private set; }
}