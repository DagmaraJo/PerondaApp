namespace PerondaApp.Entities
{
    public class BusinessPartner : EntityBase
    {
        public string? Name { get; set; }

        public override string ToString() => ($"BusinessPartner ID: {Id}, Name: {Name}");
    }
}
