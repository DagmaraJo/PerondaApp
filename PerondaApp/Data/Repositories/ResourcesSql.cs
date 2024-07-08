namespace PerondaApp.Data.Repositories;

using Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
using static PerondaApp.Data.Entities.EntityBase;

public class ResourcesSQlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly PerondaAppDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public ResourcesSQlRepository(PerondaAppDbContext dbContext) 
        //ItemAdded? itemAdded = null, ItemRemoved? itemRemoved = null)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public event EventHandler<T> ItemAdded;
    public event EventHandler<T> ItemRemoved;

    public void Add(T item)
    {
        _dbSet.Add(item);
        _dbContext.SaveChanges();
        ItemAdded.Invoke(this, item);
    }

    public IEnumerable<T> GetAll()
    {
        //return _dbSet.ToList();
        return _dbSet.OrderBy(item => item.Id).ToList();
    }
    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public T? GetItem(string name)
    {
        var id = 0;
        foreach (var item in _dbSet)
        {
            if (item.GetType().Name == name)
            {
                id = item.Id;
            }
        }
        return _dbSet.Find(name);
        //return _dbSet.Find(id);
    }
    
    public void Remove(T item)
    {
        if (item != null)
        {
            _dbSet.Remove(item);
            _dbContext.SaveChanges();
            ItemRemoved.Invoke(this, item);
        }
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }

    //public void UpdateItem(T item) { }

    public IEnumerable<T> Read()
    {
        return _dbSet.ToList();
    }

    public int GetListCount()
    {
        return Read().ToList().Count;
    }
















    //private List<T> _items = new();

    //private readonly string path = $"Resources\\Files\\{typeof(T).Name}_resourcesApdate.json";
    //public event EventHandler<T>? ItemAdded;
    //public event EventHandler<T>? ItemRemoved;
    ////public event EventHandler<T>? ItemSaved;

    //private int lastUsedId = 1;
    //private string? s;

    //public IEnumerable<T> GetAll()
    //{
    //    //return _items.ToList();
    //    if (File.Exists(path))
    //    {
    //        var objectsSerialized = File.ReadAllText(path);
    //        var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
    //        if (deserializedObjects is not null)
    //        {
    //            _items = new List<T>();
    //            foreach (var items in deserializedObjects)
    //            {
    //                _items.Add(items);
    //            }
    //        }
    //    }
    //    return _items;
    //}

    //public T? GetById(int id)
    //{
    //    //return _items.Single(item => item.Id == id);
    //    var itemById = _items.SingleOrDefault(item => item.Id == id);
    //    if (itemById == null)
    //    {
    //        //Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine($" {typeof(T).Name} with id {id} not found.");
    //        //Console.ResetColor();
    //    }
    //    return itemById;
    //}

    //public void Add(T item)
    //{
    //    //if (_items.Count == 0)
    //    //{
    //    //    item.Id = lastUsedId;
    //    //    lastUsedId++;
    //    //}
    //    //else if (_items.Count > 0)
    //    //{
    //    //    lastUsedId = _items[_items.Count - 1].Id;
    //    //    item.Id = ++lastUsedId;
    //    //}

    //    ////item.Id = _items.Count + 1;
    //    ////_items.Add(item);

    //    int newId;
    //    if (_items.Count == 0)
    //    {
    //        newId = 1;
    //    }
    //    else
    //    {
    //        var currentId = _items
    //           .OrderBy(item => item.Id)
    //           .Select(item => item.Id)
    //           .Last();
    //        newId = currentId + 1;
    //    }
    //    item.Id = newId;
    //    _items.Add(item);
    //    ItemAdded?.Invoke(this, item);
    //}

    //public void Remove(T item)
    //{
    //    _items.Remove(item);
    //    ItemRemoved?.Invoke(this, item);
    //}

    //public void Save()
    //{
    //    foreach (var item in _items)
    //    {
    //        s = item.ToString();
    //        Console.WriteLine(s);
    //    }
    //    File.Delete(path);
    //    var objectsSerialized = JsonSerializer.Serialize<IEnumerable<T>>(_items);
    //    File.WriteAllText(path, objectsSerialized);
    //}

    //public IEnumerable<T> Read()
    //{
    //    if (File.Exists(path))
    //    {
    //        var objectsSerialized = File.ReadAllText(path);
    //        var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
    //        if (deserializedObjects != null)
    //        {
    //            foreach (var item in deserializedObjects)
    //            {
    //                _items.Add(item);
    //            }
    //        }
    //    }
    //    return _items;
    //}

    //public int GetListCount()
    //{
    //    return _items.Count;
    //}

    ////public T CreateNewItem()
    ////{
    ////    return new T();
    ////}
}
