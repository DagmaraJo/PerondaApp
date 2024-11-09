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
}