namespace PerondaApp.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
