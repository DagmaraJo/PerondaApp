﻿using PerondaApp.Data.Entities;

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

    public static void AddBatch<T>(this string s, T[] items)
    where T : class, IEntity
    {
        //s.
    }
}
