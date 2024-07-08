using PerondaApp.Data.Repositories;

namespace PerondaApp.Data.Entities
{
    public abstract class EntityBase : IEntity
    {
        public delegate void ItemAdded(object sender, EventArgs args);
        public delegate void ItemRemoved(object sender, EventArgs args);
        public int Id { get; set; }
    }
}
