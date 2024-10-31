namespace PerondaApp.Entities;

public abstract class Person : EntityBase, IEntity
{
    public string? FirstName { get; set; }

    public string? Surname { get; set; }

    public string? Position { get; set; }

    public string? Company { get; set; }

    public string? Adress { get; private set; }

    public int? TelNumb { get; private set; }

    public string? EMail { get; private set; }

    public new string FullName => $" {FirstName} {Surname}";
}