using PerondaApp.Data.Entities;

namespace PerondaApp.Data.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{

}
