using PerondaApp.Data.Entities;

namespace PerondaApp.Data.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{
    //public delegate void ItemAddedCallback(object item);
    //public delegate void ItemRemovedCallback(object item);
    public delegate void ItemAdded<in T>(T item);
    public delegate void ItemRemoved<in T>(T item);




    public const string fileName = "Resources\\Files\\audit.txt";

    //public delegate void ItemAdded<in T>(T item);

   // public event EventHandler<T>? ItemRemoved;
}
