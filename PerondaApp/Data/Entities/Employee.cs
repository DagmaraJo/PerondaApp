namespace PerondaApp.Data.Entities
{
    public class Employee : Person
    {
        public override string ToString() => $" ID: {Id}  {FullName}   >> {GetType().Name}";
    }
}
