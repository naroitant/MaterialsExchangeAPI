namespace MaterialsExchangeAPI.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; private set; }

    public void SetId(int id)
    { 
        Id = id; 
    }
}
