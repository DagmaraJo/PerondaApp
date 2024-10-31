namespace PerondaApp.Entities
{
    public class Employee : Person, IEntity
    {
        public override string ToString() => $"  {GetType().Name}  >>>  " + base.ToString() + $"  ♦ {Position} -- {Company}";
    }
}
