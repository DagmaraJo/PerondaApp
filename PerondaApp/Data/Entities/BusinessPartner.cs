namespace PerondaApp.Data.Entities
{
    public class BusinessPartner : Person
    {
        public string? Name { get; set; }

        public override string ToString() => $" ID: {Id} {FullName} {Position} {Name}   * Business Partner";
    }
}
