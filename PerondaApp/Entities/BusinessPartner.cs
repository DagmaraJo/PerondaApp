namespace PerondaApp.Entities
{
    public class BusinessPartner : Person, IEntity
    {
        public string? CompanyName { get; set; }

        public override string ToString() => base.ToString() + $"  @ {Position} -- {CompanyName}  * {GetType().Name}  ";
    }
}
