namespace weges_v2.ApiModel.Models;

public interface IEntity<KType>
{
    KType Id { get; set; }
}