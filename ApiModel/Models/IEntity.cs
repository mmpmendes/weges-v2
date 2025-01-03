namespace ApiModel.Models;

public interface IEntity<KType>
{
    KType Id { get; set; }
}