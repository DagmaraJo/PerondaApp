using PerondaApp.Entities;

namespace PerondaApp.Repositories.Extensions;

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

    public static void AddBatchString<T>(this string _, T[] items)
    where T : class, IEntity
    {
        _ = $" {items} added";
    }

    public static void RemoveBatch<T>(this IRepository<T> repository, T[] items, string action)
    where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Remove(item);
        }
        repository.Save();
    }

    public static void RemoveBatch<T>(this string _, T[] items)
    where T : class, IEntity
    {
        _ = $" {items} removed";
    }

    public static void AddBatchWithSaveAuditAndInfoColor<T>(this IRepository<T> repository, T[] items, string action)
        where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }
        repository.Save();
        _ = $" {items} added";
        if (items is not null)
        {
            action = $" | + |  added  ] ";
            repository.SaveAuditItems(action, items);
            //WriteItemAdded(e);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  new  {items}  successfully added  ");
            Console.ResetColor();
        }
    }

    public static void RemoveBatchInfoColor<T>(this IRepository<T> repository, T[] items, string action)
    where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Remove(item);
        }
        repository.Save();
        repository.SaveAuditItems(action, items);

        if (items is not null)
        {
            action = $" | + | removed ] ";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"    {items}   just REMOVED");
            Console.ResetColor();
        }
    }
}