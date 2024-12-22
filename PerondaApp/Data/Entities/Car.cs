namespace PerondaApp.Data.Entities;

public class Car : EntityBase
{
    public int Year { get; set; }

    public string? Manufacturer { get; set; }

    public string? Name { get; set; }

    public double Displacement { get; set; }

    public int Cylinders { get; set; }

    public int City { get; set; }

    public int Highway { get; set; }

    public int Combined { get; set; }

    public override string ToString() => base.ToString() + $" model: {Name}, Manufacturer: {Manufacturer}  __displ. {Displacement} /city {City}_comb: {Combined}/high:{Highway}/cyl:{Cylinders}";
}