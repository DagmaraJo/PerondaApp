namespace PerondaApp.Entities
{
    public class Employee : Person, IEntity
    {
        public override string ToString() => base.ToString() + $" >> {GetType().Name} >>  {Position} ";
    }
}
