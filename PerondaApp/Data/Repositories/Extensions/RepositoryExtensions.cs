using PerondaApp.Data.Entities;
using static PerondaApp.Services.UserCommunicationBase;

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
        string action = $" | + |  added   {e.GetType().Name}  {e}";
        SaveActionInAudit(e, action);
        WritelineColor($"\n  new  {e.GetType().Name}  ID : {e.Id}\n" +
            $"                  {e}\n  successfully added", ConsoleColor.Green);
    }

    private static void RepositoryOnItemRemoved<T>(object? sender, T e) where T : class, IEntity
    {
        string action = $"    -  removed   {e.GetType().Name}  {e}";
        SaveActionInAudit(e, action);
        WritelineColor($" process completed :\n    {e}\n    just REMOVED", ConsoleColor.Blue);
    }

    private static void SaveActionInAudit<T>(T e, string action) where T : class, IEntity
    {
        using var writer = File.AppendText(IRepository<IEntity>.fileName);
        writer.WriteLine($"  {DateTime.UtcNow} {action}");
    }

    //public static void RemoveBatch<T>(this IRepository<T> repository, T[] items)
    //where T : class, IEntity
    //{
    //    foreach (var item in items)
    //    {
    //        repository.Remove(item);
    //    }
    //    repository.Save();
    //}

    public static T? FindItemByName<T>(this IReadRepository<T> repository) where T : class, IEntity
    {
        string name = GetInputWrite(" Enter model name to find:  ");
        var item = repository.GetByName(name);
        if (item == null)
        {
            WritelineColor($"\n\tCar model {name} not found.\n", ConsoleColor.Magenta);
        }
        if (item != null)
        {
            WritelineColor($"\t found model car :\n", ConsoleColor.DarkGray);
            WritelineColor($" {item}", ConsoleColor.Cyan);
        }
        return item;
    }

    public static void RemoveItem<T>(this IRepository<T> repository) where T : class, IEntity
    {
        WritelineColor($"\t\t\t [[__ D E L E T E __]]", ConsoleColor.DarkCyan);
        //var item = FindItemByOptions(repository);
        //if (item != null)
        //{
        //    var userChoice = GetInputFromUser("  Enter R_to confirm Remove, press any to leave").ToUpper();
        //    if (userChoice == "R") { repository.Remove(item); repository.Save(); }
        //    //if (userChoice == "X") { break; }
        //}
        do 
        {
            var itemId = FindItemById(repository);
            var item = FindItemByName(repository);
            if (itemId != null || item != null)
            {
                var userChoice = GetInputFromUser("  Enter R_to confirm Remove   X - to leave").ToUpper();
                if (userChoice == "R") { repository.Remove(itemId!); repository.Remove(item!); break; }
                if (userChoice == "X") { break; }
            }
        }
        while (true);
    }

    public static void WriteAllToConsole<T>(this IReadRepository<T> repository) where T : class, IEntity
    {
        WritelineColor($"  Viev all:    _The {typeof(T).Name}s list_ ", ConsoleColor.DarkCyan);
        var items = repository.GetAll();
        if (items != null)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        else { WritelineColor("\n      This list is empty.", ConsoleColor.Red); }
    }

    public static T? FindItemById<T>(this IRepository<T> repository) where T : class, IEntity
    {
        var choiceId = GetInputWrite("\nEnter ID : ");
        int outputIDValue;
        var isParsed = int.TryParse(choiceId, out outputIDValue);  //var itemId = repository.Updata(outputIDValue);
        var itemId = repository.GetById(outputIDValue);
        if (!isParsed)
        {
            WritelineColor("  ID Number should be an INTEGER ,  Enter correct format\n", ConsoleColor.Red);
        }
        if (isParsed)
        {
            if (itemId == null)
            {
                WritelineColor($"\n\t{typeof(T).Name} with  ID {outputIDValue} not found.", ConsoleColor.Magenta);
            }
            if (itemId != null)
            {
                Console.WriteLine($"\t\t found {typeof(T).Name}\n", ConsoleColor.DarkGray);
                WritelineColor($" {itemId}", ConsoleColor.Cyan);
            }
        }

        return itemId;
    }
}