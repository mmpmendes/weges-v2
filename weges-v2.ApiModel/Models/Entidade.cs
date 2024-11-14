namespace weges_v2.ApiModel;

public abstract class Entidade<T>
{
    public T Id { get; private set; }
    public DateTime Created { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime Modified { get; private set; }
    public string ModifiedBy { get; private set; }
}