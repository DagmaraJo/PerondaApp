using Microsoft.EntityFrameworkCore;
using PerondaApp.Data.Entities;

namespace PerondaApp.Data.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly PerondaAppDbContext _perondaAppDbContext;
    private readonly DbSet<T> _dbSet;

    public SqlRepository(PerondaAppDbContext perondaAppDbContext)
    {
        _perondaAppDbContext = perondaAppDbContext;
        _dbSet = perondaAppDbContext.Set<T>();
    }

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public event EventHandler<T> ItemUpdated;

    public IEnumerable<T> GetAll()
    {
        return _dbSet.OrderBy(item => item.Id).ToList();
    }

    public T? GetById(int id)

    {
        return _dbSet.Find(id);
    }

    public void Add(T item)
    { 
        _dbSet.Add(item);
        Save();
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        Save();
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        _perondaAppDbContext.SaveChanges();
    }

    public IEnumerable<T> Read()
    {
        return _dbSet.ToList();
    }

    public int GetCount()
    {
        return Read().ToList().Count;
    }

    public T GetByName(string name)
    {
        return _dbSet.FirstOrDefault(x => x.Name == name)!;
    }
}