//using PerondaApp.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using static PerondaApp.Data.Entities.EntityBase;
//using static PerondaApp.Data.Repositories.IRepository<T>;

//namespace PerondaApp.Data.Repositories;

////public delegate void ItemAddedCallback(object item);
//public delegate void ItemRemovedCallback(object item);
////public delegate void ItemAdded<in T>(T item);
//public delegate void ItemRemoved(object item);

//public class SqlRepoToFileTxt<T> : IRepository<T> where T : class, IEntity, new()
//{
//    private readonly DbContext _dbContext;
//    private readonly DbSet<T> _dbSet;
//    private readonly ItemAddedCallback? _itemAddedCallback;
//    private readonly ItemRemovedCallback? _itemRemovedCallback;
//    private readonly ItemAdded? _itemAdded;
//    private readonly ItemRemoved? _itemRemoved;

//    public SqlRepoToFileTxt(DbContext dbContext, 
//        ItemAddedCallback? itemAddedCallback = null, ItemRemovedCallback? itemRemovedCallback = null)
//    {
//        _dbContext = dbContext;
//        _dbSet = _dbContext.Set<T>();
//        //_itemAddedCallback = itemAddedCallback;
//        //_itemRemovedCallback = itemRemovedCallback;
//        _itemAdded = itemAdded;
//        _itemRemoved = itemRemoved;
//    }

//    public event EventHandler<T>? ItemAdded;      //  przy tworzeniu SqlRepository można nie podawać callBacka w nawiasie ItemAdded? itd../\ patrz wyżej
//    public event EventHandler<T>? ItemRemoved;

//    public IEnumerable<T> GetAll()
//    {
//        return _dbSet.ToList();
//    }

//    public T? GetById(int id)
//    {
//        return _dbSet.Find(id);
//    }

//    public void Add(T item)
//    {
//        _dbSet.Add(item);
//        _itemAdded?.Invoke(item);  // tu jest wywołanie, przekazanie w invoke
//        //ItemAdded?.Invoke(this, item);   //  EventHandler<T>
//    }

//    public void Remove(T item)
//    {
//        _dbSet.Remove(item);
//        _itemRemovedCallback?.Invoke(item);
//        //ItemRemoved?.Invoke(this, item);   //  EventHandler<T>
//    }

//    public void Save()
//    {
//        _dbContext.SaveChanges();
//    }

//    IEnumerable<T> IReadRepository<T>.Read()
//    {
//        throw new NotImplementedException();
//    }

//    int IReadRepository<T>.GetListCount()
//    {
//        throw new NotImplementedException();
//    }
//}
///*
//public void Add(TEntity item)
//{
//    _dbSet.Add(item);
//    //item.Id = items.Count + 1;
//    int newId = item.Id;
//    for (newId = item.Id; newId < int.MaxValue; newId++)
//    {
//        Console.ForegroundColor = ConsoleColor.DarkGray;
//        Console.WriteLine("\n\tChecking available ID numbers...");
//        Console.ResetColor();
//        item.Id = newId;

//        if (items.Any(x => x.Id == item.Id))
//        {
//            Console.ForegroundColor = ConsoleColor.DarkMagenta;
//            Console.WriteLine("\tId already taken. Looking for a new ID for this item\n");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.DarkYellow;
//            Console.WriteLine("\tSuccess! ID assigned\n");
//            Console.ResetColor();
//            item.Id = newId;
//            break;
//        }
//        items.Add(item);
//        using (var writer = File.AppendText(JsonFile))
//        {
//            writer.WriteLine(item);
//        }
//        _itemAddedCallback?.Invoke(item);
//        ItemAdded?.Invoke(this, item);
//        AuditEntry?.Invoke(this, item);
//    }
//}
//*/
