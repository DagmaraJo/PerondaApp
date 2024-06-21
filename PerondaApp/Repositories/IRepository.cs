using PerondaApp.Entities;

namespace PerondaApp.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{
   
}
