namespace PerondaApp.Data.Entities;

public class Manufacturer : EntityBase, IEntity
{
    public string Name { get; set; }
    public string Country { get; set; }
    public  int Year { get; set; }

    public override string ToString() => base.ToString() + $"{Name} /country: {Country}";
}
