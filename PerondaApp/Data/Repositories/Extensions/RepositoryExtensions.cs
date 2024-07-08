using PerondaApp.Data.Entities;

namespace PerondaApp.Data.Repositories.Extensions;

public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IRepository<T> repository, T[] items)
    where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }
        repository.Save();
    }

    public static void AddBatch<T>(this string _, T[] items)
    where T : class, IEntity
    {
        _ = $" {items} added";
    }

    public static void RemoveBatch<T>(this IRepository<T> repository, T[] items)
    where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Remove(item);
        }
        repository.Save();
    }

    public static void RemoveBatch<T>(this string s, T[] items)
    where T : class, IEntity
    {
        
    }

    /*
    public static void SetUp<T>(this IRepository<T> repository) where T : class, IEntity
    {
        repository.ItemAdded<T> += RepositoryOnItemAdded;
        repository.ItemRemoved<T> += RepositoryOnItemRemoved;
    }

    public static void RepositoryOnItemAdded<T>(object? sender, T e) where T : class, IEntity
    {
        using (var writer = File.AppendText("OfficeBaseApp_Backlog.TXT"))
        {
            if (!sender.GetType().Name.IsNullOrEmpty())
            {
                Console.WriteLine($"{e.GetType().Name} {e.Name} added to {sender?.GetType().Name.Remove(sender.GetType().Name.Length - 2)}");
                writer.WriteLine($"{DateTime.Now} ---> {e.GetType().Name} {e.Name} added to {sender?.GetType().Name.Remove(sender.GetType().Name.Length - 2)}");
            }
        }
    }

    public static void RepositoryOnItemRemoved<T>(object? sender, T e) where T : class, IEntity
    {
        using (var writer = File.AppendText("OfficeBaseApp_Backlog.TXT"))
        {
            if (!sender.GetType().Name.IsNullOrEmpty())
            {
                Console.WriteLine($"{e.GetType().Name} {e.Name} removed from {sender.GetType().Name.Remove(sender.GetType().Name.Length - 2)}");
                writer.WriteLine($"{DateTime.Now} ---> {e.GetType().Name} {e.Name} removed from {sender?.GetType().Name.Remove(sender.GetType().Name.Length - 2)}");
            }
        }
    }
    public static void WriteAllToConsole(this IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    */
}