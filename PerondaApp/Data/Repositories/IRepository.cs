using PerondaApp.Data.Entities;

namespace PerondaApp.Data.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{
    public const string fileName = "Resources\\Files\\audit.txt";

    public const string fileJsonName = "Resources\\Files\\save.json";

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    //public delegate void ItemAddedCallback(object item);
    //public delegate void ItemRemovedCallback(object item);
    //public delegate void ItemAdded<in T>(T item);
    //public delegate void ItemRemoved<in T>(T item);
}
