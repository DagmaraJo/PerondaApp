namespace PerondaApp.Data.Entities;

public abstract class EntityBase : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public override string ToString() => $" ID_ {Id}  {GetType().Name}";
}
