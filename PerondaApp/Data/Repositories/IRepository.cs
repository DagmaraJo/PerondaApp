using PerondaApp.Data.Entities;

namespace PerondaApp.Data.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{
    public const string fileName = "Resources\\Files\\audit.txt";

    public const string fileJsonName = "Resources\\Files\\save.json";

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
}
