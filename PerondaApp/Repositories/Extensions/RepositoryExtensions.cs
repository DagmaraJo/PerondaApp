using PerondaApp.Entities;
using static PerondaApp.Services.UserCommunicationBase;

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

    public static void SequenceEvents<T>(this IRepository<T> repository) where T : class, IEntity
    {
        repository.ItemAdded += RepositoryOnItemAdded;
        repository.ItemRemoved += RepositoryOnItemRemoved;
    }

    private static void RepositoryOnItemAdded<T>(object? sender, T e) where T : class, IEntity
    {
        string action = ( $" | + |  added   {e.GetType().Name}   ID : {e.Id}  {e.FullName}");
        SaveActionInAudit(e, action);
        WritelineColor($"\n  new  {e.GetType().Name}  ID : {e.Id}\n" +
            $"                  {e.FullName}\n  successfully added", ConsoleColor.Green);
    }

    private static void RepositoryOnItemRemoved<T>(object? sender, T e) where T : class, IEntity
    {
        string action = ($"    -  removed   {e.GetType().Name}  ID : {e.Id}  {e.FullName}");
        SaveActionInAudit(e, action);
        WritelineColor($" process completed :\n    {e}\n    just REMOVED", ConsoleColor.Blue);
    }

    private static void SaveActionInAudit<T>(T e, string action) where T : class, IEntity
    {
        using var writer = File.AppendText(IRepository<IEntity>.fileName);
        writer.WriteLine($"  {DateTime.UtcNow} {action}");
    }
}