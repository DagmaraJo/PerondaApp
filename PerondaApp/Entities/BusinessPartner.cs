namespace PerondaApp.Entities
{
    public class BusinessPartner : EntityBase, IEntity
    {
        public string? FirstName { get; set; }

        public string? Surname { get; set; }

        public string? Position { get; set; }

        public string? Company { get; set; }

        public string? CompanyAdress { get; private set; }

        public int? TelNumb { get; private set; }

        public string? EMail { get; private set; }

        public string FullName => $" {FirstName} {Surname} ";

        public override string ToString() => $" {GetType().Name}   ID: {Id}  {FullName} +   @ {Position} -- {Company}";
    }
}
