//namespace PerondaApp.Data.Repositories;

//using Microsoft.EntityFrameworkCore;
//using PerondaApp.Data.Entities;

//public delegate void ItemAdded<in T>(T item);
//public delegate void ItemAddedCallback(object item);
//public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
//{
//    private readonly DbContext _dbContext;
//    private readonly DbSet<T> _dbSet;
//    private readonly ItemAdded<T>? _itemAdded;

//    public SqlRepository(DbContext dbContext, ItemAddedCallback? itemAddedCallback = null,   //wcześniej było żle Action<T>
//         ItemAdded<T>? itemAdded = null,                                   //EventHandler<T>? itemAdded = null,
//                                             EventHandler<T>? itemRemoved = null)

//    {
//        _dbContext = dbContext;
//        _dbSet = _dbContext.Set<T>();
//        _itemAdded = itemAdded;
//    }

//    public event ItemAdded<T>? ItemAdded;

//    public event EventHandler<T>? ItemRemoved;

//    public IEnumerable<T> GetAll()
//    {
//        return _dbSet.OrderBy(item => item.Id).ToList();
//    }

//    public T? GetById(int id)
//    {
//        return _dbSet.Find(id);
//    }

//    public void Add(T item)
//    {
//        _dbSet.Add(item);
//        _dbContext.SaveChanges();
//        ItemAdded?.Invoke(this, item);
//    }

//    public void Remove(T item)
//    {
//        _dbSet.Remove(item);
//        _dbContext.SaveChanges();
//        ItemRemoved?.Invoke(this, item);
//    }

//    public void Save()
//    {
//        _dbContext.SaveChanges();
//    }

//    public IEnumerable<T> Read()
//    {
//        return _dbSet.ToList();
//    }

//    public int GetListCount()
//    {
//        return Read().ToList().Count;
//    }
//}